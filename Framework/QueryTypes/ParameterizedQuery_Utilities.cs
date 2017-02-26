using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using ParameterizedQuery.Framework.Entities;
using ParameterizedQuery.Framework.Extensions;

// ReSharper disable CheckNamespace

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	[SuppressMessage ("ReSharper", "ClassCannotBeInstantiated")]
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private methods.

		/// <summary>
		/// Gets the value of the local variable represented by the memberExpression expression.
		/// </summary>
		/// <param name="memberExpression">The member expression containing the local variable.</param>
		/// <param name="localVariableName">The name of the local variable.</param>
		/// <param name="localVariableValue">The value of the local variable.</param>
		/// <param name="localVariableType">The data type of the localvariable.</param>
		/// <returns></returns>
		private void ExtractLocalVariableFromExpression
			(
				MemberExpression memberExpression,
				out string localVariableName,
				out object localVariableValue,
				out Type localVariableType
			)
		{
			// Prepare a lambda from the memberExpression expression.
			var objectMember = Expression.Convert (memberExpression, typeof (object));
			var getterLambda = Expression.Lambda<Func<object>> (objectMember);
			var getter = getterLambda.Compile ();

			// Get the variable name, and value.
			localVariableName = memberExpression.Member.Name;
			localVariableValue = getter ();

			// Get the variable property's data type.
			var localVariableInfo = memberExpression.Member as FieldInfo;

			// Was the local variable info extracted?
			if (localVariableInfo == null)
			{
				// No.
				throw (new ParameterizedQueryException ("Cannot identify the type of the variable \"" + localVariableName + "\" used in the query."));
			}

			// Get the local variable type.
			localVariableType = localVariableInfo.FieldType;
		}

		/// <summary>
		/// Extracts a date value in DateTime (yyyy, MM, dd) format to a T-SQL query parameter.
		/// </summary>
		/// <param name="leftOrRightPart">The left or right side of a boolean expression.</param>
		/// <param name="sqlQueryParameter">The corresponding T-SQL query parameter that contains the extracted date value.</param>
		private void ExtractHardCodedDateFromLocalVariable
			(
				Expression leftOrRightPart,
				out SqlQueryParameter sqlQueryParameter
			)
		{
			// The expectation is that the date is set with a value using "= new DateTime (yyyy, MM, dd)" syntax.
			// Hence, the statement is expected to be a "new ()" expression.
			var newExpression = leftOrRightPart as NewExpression;
			sqlQueryParameter = null;

			// Is it a "new ()" expression?
			if (newExpression != null)
			{
				// Get the year, month and date parts from the constructor arguments.
				var yearMonthAndDateParts
					= newExpression
						.Arguments
						.Select (v => Int32.Parse (v.ToString ()))
						.ToList ();

				// Form the date from the yyyy, MM, and dd parts.
				var dateValue = new DateTime (yearMonthAndDateParts [0], yearMonthAndDateParts [1], yearMonthAndDateParts [2]);
				var dateText = dateValue.ToString (ORACLE_DATE_FORMAT);

				// Prepare the T-SQL parameter.
				sqlQueryParameter = new SqlQueryParameter (SQL_PARAM_DATE_VALUE_PREFIX + DateTime.Now.ToString (DATE_TIME_STAMP_FORMAT), dateText, SqlDbType.DateTime);
			}
		}

		/// <summary>
		/// Gets the local variable value, and type from the specified member expression.
		/// </summary>
		/// <param name="localVarExpression">The member expression with the local variable.</param>
		/// <param name="localVariableName">The name of the local variable.</param>
		/// <param name="localVariableValue">The value of the local variable.</param>
		/// <param name="localVariableType">The type of the local variable.</param>
		/// <param name="sqlQueryParameter">The T-SQL query parameter corresponding to the local variable found.</param>
		private bool AreLocalVariableDetailsExtractable
			(
				Expression localVarExpression,
				out string localVariableName,
				out object localVariableValue,
				out Type localVariableType,
				out SqlQueryParameter sqlQueryParameter
			)
		{
			try
			{
				// Get the member expression.
				var memberExpression = localVarExpression as MemberExpression;

				// Is it a valid member expression?
				if (memberExpression == null)
				{
					// No.
					localVariableName = String.Empty;
					localVariableValue = null;
					localVariableType = null;
					sqlQueryParameter = null;

					return (false);
				}

				// Get the local variable value, and its details.
				this.ExtractLocalVariableFromExpression
					(
						memberExpression,
						out localVariableName,
						out localVariableValue,
						out localVariableType
					);

				// Form the SQL parameter based on data types.
				if (localVariableType == typeof (char))
				{
					// Char.
					sqlQueryParameter = new SqlQueryParameter (PARAM_PREFIX + localVariableName, localVariableValue.ToString (), SqlDbType.NChar);
				}
				else if (localVariableType == typeof (string))
				{
					// String.
					sqlQueryParameter = new SqlQueryParameter (PARAM_PREFIX + localVariableName, localVariableValue.ToString (), SqlDbType.NVarChar);
				}
				else if (localVariableType.IsNumber ())
				{
					// Numeric - short, int, long, etc.
					sqlQueryParameter = new SqlQueryParameter (PARAM_PREFIX + localVariableName, localVariableValue.ToString (), SqlDbType.BigInt);
				}
				else if (localVariableType == typeof (DateTime))
				{
					// DateTime.
					var dateValue = (DateTime) localVariableValue;
					sqlQueryParameter = new SqlQueryParameter (PARAM_PREFIX + localVariableName, dateValue.ToString (ORACLE_DATE_FORMAT), SqlDbType.DateTime);
				}
				else
				{
					// Unknown, or un-handleable type. Cannot continue.
					throw (new NotImplementedException ("Processing of SQL parameter for type \"" + localVariableType.Name + "\" is not yet implemented."));
				}

				return (true);
			}
			catch
			{
				// The provided expression IS NOT a member expression.
				// Hence, the local variable cannot be extracted.
				localVariableName = String.Empty;
				localVariableValue = null;
				localVariableType = null;
				sqlQueryParameter = null;
				return (false);
			}
		}

		/// <summary>
		/// Extracts the property type, from the left or right side of a boolean expression.
		/// </summary>
		/// <param name="expressionPart">The right or left part of a boolean expression.</param>
		/// <param name="memberPropertyInfo">The property info of the property.</param>
		/// <param name="memberPropertyText">The text of the property usage in the expression part.</param>
		/// <param name="memberPropertyType">The type of the property in the expression part.</param>
		private bool IsPropertyPartExtractbleFromExpression
			(
				Expression expressionPart,
				out PropertyInfo memberPropertyInfo,
				out string memberPropertyText,
				out Type memberPropertyType
			)
		{
			try
			{
				MemberExpression property;

				// Try casting as a method call.
				var methodCall = expressionPart as MethodCallExpression;              // Example:  { c.Grade.In (10, 11, 12) }

				// Is it a method?
				if (methodCall != null)
				{
					// Yes.
					var propertyCallingInMethod = methodCall.Arguments [0];                 // Example:  { c.Grade }
					memberPropertyText = propertyCallingInMethod.ToString ();               // Example: "c.Grade"
					property = (MemberExpression) propertyCallingInMethod;                  // Example:  { c.Grade }
				}
				else
				{
					// Not a method call. Next possibility is a "property" reference (like, "c.Grade").
					property = (MemberExpression) expressionPart;
					memberPropertyText = property.ToString ();
				}

				// Get the property details.
				var propertyName = property.Member.Name;                                // Example:  "Grade"
				var parentEntity = property.Member.DeclaringType;                       // Example:  The "ClassRoom" entity.

				// Is there a parent type?
				if (parentEntity == null)
				{
					// No.
					memberPropertyText = String.Empty;
					memberPropertyType = null;
					memberPropertyInfo = null;

					return (false);
				}

				// Find the localVarExpression property type.
				memberPropertyInfo
					= parentEntity
						.GetProperties () // Get all the properties of the entity.
						.FirstOrDefault (p => p.Name == propertyName);       // Find the matching property.

				// Is there a member property?
				if (memberPropertyInfo == null)
				{
					// No.
					memberPropertyText = String.Empty;
					memberPropertyType = null;

					return (false);
				}

				memberPropertyType = memberPropertyInfo.PropertyType;

				// Refine the member property text (i.e., from "s.FirstName" to "s.nome_firsto" considering the DB name.
				memberPropertyText = memberPropertyText.Replace (propertyName, this.GetDbColumnNameOf (memberPropertyInfo));

				return (true);
			}
			catch
			{
				memberPropertyText = String.Empty;
				memberPropertyType = null;
				memberPropertyInfo = null;

				return (false);
			}
		}

		/// <summary>
		/// Extracts the date elements from the specified expression representing
		/// a date array.
		/// </summary>
		/// <param name="expression">The expression containing the dates array.</param>
		/// <returns></returns>
		private DateTime [] ExractDatesArrayFrom (Expression expression)
		{
			MemberExpression property;

			// Try casting as a method call.
			var methodCall = expression as MethodCallExpression;              // Example:  { c.Grade.In (10, 11, 12) }

			// Is it a method?
			if (methodCall != null)
			{
				// Yes.
				var propertyCallingInMethod = methodCall.Arguments [0];                 // Example:  { c.Grade }
				property = (MemberExpression) propertyCallingInMethod;                  // Example:  { c.Grade }
			}
			else
			{
				// Not a method call. Next possibility is a "property" reference (like, "s.DateofBirth").
				property = (MemberExpression) expression;
			}

			// Get the property details.
			var propertyName = property.Member.Name;                                // Example:  "Grade"
			var parentEntity = property.Member.DeclaringType;                       // Example:  The "ClassRoom" entity.

			// Find the localVarExpression property type.
			var memberProperty
				// ReSharper disable once PossibleNullReferenceException
				= parentEntity
					.GetProperties () // Get all the properties of the entity.
					.FirstOrDefault (p => p.Name == propertyName);       // Find the matching property.
			
			// Is it a member property call (such as, c.Grade)?
			if (memberProperty == null)
			{
				// No. It is likely to be a local variable.
				string localVariableName;
				object localVariableValue;
				Type localVariableType;

				// Treat the member expression as a local variable assignment.
				this.ExtractLocalVariableFromExpression
					(
						property,
						out localVariableName,
						out localVariableValue,
						out localVariableType
					);

				// Take out the dates held by the local variable.
				return ((DateTime []) localVariableValue);
			}

			throw (new ParameterizedQueryException ("The specified expression does not have date values in it."));
		}

		/// <summary>
		/// Gets the alias corresponding to the table entity specified.
		/// </summary>
		/// <param name="entity">The table entity.</param>
		/// <returns></returns>
		private string GetAliasForTable (Type entity)
		{
			return
				(
					this.tableAliasesDictionary
						.Keys
						.FirstOrDefault (k => this.tableAliasesDictionary [k] == entity)
				);
		}

		/// <summary>
		/// Gets the table entity corresponding to the alias specified.
		/// </summary>
		/// <param name="alias">The table alias.</param>
		/// <returns></returns>
		private Type GetTableForAlias (string alias)
		{
			// Does the alias exist?
			if (this.tableAliasesDictionary.ContainsKey (alias) == false)
			{
				// No.
				throw (new ParameterizedQueryException ("The specified alias, \"" + alias + "\" does not correspond to any of the registered aliases for tables."));
			}

			return (this.tableAliasesDictionary [alias]);
		}

		/// <summary>
		/// Gets the DB name of the table entity specified.
		/// </summary>
		/// <param name="tableEntityType">The table entity whose DB name is to be extracted.</param>
		/// <returns></returns>
		private string GetDbTableNameOf (Type tableEntityType)
		{
			// Get the DbColumnName attribute.
			var tableName = tableEntityType.GetCustomAttributes<DbTableAttribute> ().FirstOrDefault ();

			// Is there one?
			if (tableName == null)
			{
				// No, use the property name.
				return (tableEntityType.Name);
			}

			// There is SpParanName attribute - use the name in it.
			return (tableName.DbDbTableName);
		}

		/// <summary>
		/// Gets the DB name of the property of the entity specified.
		/// </summary>
		/// <param name="property">The property whose DB name is to be extracted.</param>
		/// <returns></returns>
		private string GetDbColumnNameOf (PropertyInfo property)
		{
			// Get the DbColumnName attribute.
			var spParamName = property.GetCustomAttributes<DbColumnAttribute> ().FirstOrDefault ();

			// Is there one?
			if (spParamName == null)
			{
				// No, use the property name.
				return (property.Name);
			}

			// There is SpParanName attribute - use the name in it.
			return (spParamName.DbColumnName);
		}

		/// <summary>
		/// Gets the DB name of the property of the entity specified.
		/// </summary>
		/// <param name="tableAlias">The table alias.</param>
		/// <param name="propertyName">The name of the property.</param>
		/// <returns></returns>
		private string GetDbColumnNameOf (string tableAlias, string propertyName)
		{
			var entityType = this.GetTableForAlias (tableAlias);
			var property = entityType.GetProperties ().FirstOrDefault (p => p.Name == propertyName);

			// Is there a matching property
			if (property == null)
			{
				// No.
				throw (new ParameterizedQueryException ("Property \"" + propertyName + "\" could not be located on entity, \"" + entityType.Name + "\"."));
			}

			// Get the DB column name of the property.
			return (this.GetDbColumnNameOf (property));
		}

		#endregion
	}
}