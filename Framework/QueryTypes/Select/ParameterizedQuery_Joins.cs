using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using ParameterizedQuery.Framework.Entities;

// ReSharper disable CheckNamespace

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	[SuppressMessage ("ReSharper", "ClassCannotBeInstantiated")]
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private readonly instance fields.

		/// <summary>
		/// A list of joins in the T-SQL statement's FROM clause.
		/// </summary>
		private readonly IList<JoinInfo> fromJoins;

		#endregion

		#region The "Inner Join" methods.

		/// <summary>
		/// Helps link an entity inner join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <typeparam name="TDataType">The data type of the primary key of the from table.</typeparam>
		/// <param name="func">An expression representing the property of the "from table" that would act
		/// as the foreign key towards the primary key of the "to table".</param>
		/// <returns></returns>
		public ParameterizedSqlQuery InnerJoinWith<TFromTable, TToTable, TDataType> (Expression<Func<TFromTable, TDataType>> func)
		{
			this.AddFromClauseJoin<TFromTable, TToTable, TDataType> (func, JoinType.InnerJoin);
			return (this);
		}

		/// <summary>
		/// Helps link an entity inner join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <param name="func">A boolean expression representing the condition (one or more) between the foreign key
		/// properties of the "from table" and the primary key properties of the "to table".The criteria for these conditions to meet are:
		/// (1) Only equality operator ("==") are used, as only equality operator is expected within joins. Other comparison types such
		///     as not equali to, greater than, less than, greather than or equal to, less than or equal to, etc. are not accepted.
		/// (2) Conditions are to be joined together by simple "&&" operator only. Other operators, such as "||" and nested conditions are not expected.
		/// (3) The first part of the equlity statement represents the "from table" property, and the second part, the "to table" property.
		/// </param>
		/// <returns></returns>
		public ParameterizedSqlQuery InnerJoinWith<TFromTable, TToTable> (Expression<Func<TFromTable, TToTable, bool>> func)
		{
			this.AddFromClauseJoin (func, JoinType.InnerJoin);
			return (this);
		}

		/// <summary>
		/// Helps link an entity left join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <typeparam name="TDataType">The data type of the primary key of the from table.</typeparam>
		/// <param name="func">An expression representing the property of the "from table" that would act
		/// as the foreign key towards the primary key of the "to table".</param>
		/// <returns></returns>
		public ParameterizedSqlQuery LeftJoinWith<TFromTable, TToTable, TDataType> (Expression<Func<TFromTable, TDataType>> func)
		{
			this.AddFromClauseJoin<TFromTable, TToTable, TDataType> (func, JoinType.LeftJoin);
			return (this);
		}

		/// <summary>
		/// Helps link an entity left join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <param name="func">A boolean expression representing the condition (one or more) between the foreign key
		/// properties of the "from table" and the primary key properties of the "to table".The criteria for these conditions to meet are:
		/// (1) Only equality operator ("==") are used, as only equality operator is expected within joins. Other comparison types such
		///     as not equali to, greater than, less than, greather than or equal to, less than or equal to, etc. are not accepted.
		/// (2) Conditions are to be joined together by simple "&&" operator only. Other operators, such as "||" and nested conditions are not expected.
		/// (3) The first part of the equlity statement represents the "from table" property, and the second part, the "to table" property.
		/// </param>
		/// <returns></returns>
		public ParameterizedSqlQuery LeftJoinWith<TFromTable, TToTable> (Expression<Func<TFromTable, TToTable, bool>> func)
		{
			this.AddFromClauseJoin (func, JoinType.LeftJoin);
			return (this);
		}

		/// <summary>
		/// Helps link an entity right join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <typeparam name="TDataType">The data type of the primary key of the from table.</typeparam>
		/// <param name="func">An expression representing the property of the "from table" that would act
		/// as the foreign key towards the primary key of the "to table".</param>
		/// <returns></returns>
		public ParameterizedSqlQuery RightJoinWith<TFromTable, TToTable, TDataType> (Expression<Func<TFromTable, TDataType>> func)
		{
			this.AddFromClauseJoin<TFromTable, TToTable, TDataType> (func, JoinType.RightJoin);
			return (this);
		}

		/// <summary>
		/// Helps link an entity right join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <param name="func">A boolean expression representing the condition (one or more) between the foreign key
		/// properties of the "from table" and the primary key properties of the "to table".The criteria for these conditions to meet are:
		/// (1) Only equality operator ("==") are used, as only equality operator is expected within joins. Other comparison types such
		///     as not equali to, greater than, less than, greather than or equal to, less than or equal to, etc. are not accepted.
		/// (2) Conditions are to be joined together by simple "&&" operator only. Other operators, such as "||" and nested conditions are not expected.
		/// (3) The first part of the equlity statement represents the "from table" property, and the second part, the "to table" property.
		/// </param>
		/// <returns></returns>
		public ParameterizedSqlQuery RightJoinWith<TFromTable, TToTable> (Expression<Func<TFromTable, TToTable, bool>> func)
		{
			this.AddFromClauseJoin (func, JoinType.RightJoin);
			return (this);
		}

		/// <summary>
		/// Helps link an entity full outer join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <typeparam name="TDataType">The data type of the primary key of the from table.</typeparam>
		/// <param name="func">An expression representing the property of the "from table" that would act
		/// as the foreign key towards the primary key of the "to table".</param>
		/// <returns></returns>
		public ParameterizedSqlQuery FullOuterJoinWith<TFromTable, TToTable, TDataType> (Expression<Func<TFromTable, TDataType>> func)
		{
			this.AddFromClauseJoin<TFromTable, TToTable, TDataType> (func, JoinType.FullOuterJoin);
			return (this);
		}

		/// <summary>
		/// Helps link an entity full outer join with another entity based on one or more column(s) comparison.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type that represents the "from table" where the join is initiated.</typeparam>
		/// <typeparam name="TToTable">The generic entity type that represents the "to table" to which the join is initiated.</typeparam>
		/// <param name="func">A boolean expression representing the condition (one or more) between the foreign key
		/// properties of the "from table" and the primary key properties of the "to table".The criteria for these conditions to meet are:
		/// (1) Only equality operator ("==") are used, as only equality operator is expected within joins. Other comparison types such
		///     as not equali to, greater than, less than, greather than or equal to, less than or equal to, etc. are not accepted.
		/// (2) Conditions are to be joined together by simple "&&" operator only. Other operators, such as "||" and nested conditions are not expected.
		/// (3) The first part of the equlity statement represents the "from table" property, and the second part, the "to table" property.
		/// </param>
		/// <returns></returns>
		public ParameterizedSqlQuery FullOuterJoinWith<TFromTable, TToTable> (Expression<Func<TFromTable, TToTable, bool>> func)
		{
			this.AddFromClauseJoin (func, JoinType.FullOuterJoin);
			return (this);
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Adds the joins started from a "from" clause.
		/// NOTE: Only one condition would be present when using this method to process joins. Only the "from table" foreign key
		/// NOTE: property name is to be mentioned. The "to table" primary key property would be automatically ascerained by checking
		/// NOTE: if any of the "to table" entity properties is marked with ".IsPrimaryKey" set to true or not.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type representing the "from table" of the join.</typeparam>
		/// <typeparam name="TToTable">The generic entity type representing the "to tbale" of the join.</typeparam>
		/// <typeparam name="TDataType">The data type of the primary key of the "to table".</typeparam>
		/// <param name="func">An expression indicating the conditions of joining between the "from" and "to" tables.</param>
		/// <param name="joinType">The join type.</param>
		private void AddFromClauseJoin<TFromTable, TToTable, TDataType> (Expression<Func<TFromTable, TDataType>> func, JoinType joinType)
		{
			var fromTableType = typeof (TFromTable);
			var toTableType = typeof (TToTable);

			// Get the target "from table" property, that should be linked to the primary
			// key of the "to table".
			var argumentBody = (MemberExpression) (func.Body);
			var fromTablePropertyName = argumentBody.Member.Name;

			// Get the "from table" property that is to be linked with the "to table" property.
			var fromTableProperty
				= fromTableType
					.GetProperties ()
					.FirstOrDefault (p => p.Name == fromTablePropertyName);

			// Get the "to table" primary key property.
			var toTableProperty
				= toTableType
					.GetProperties ()
					.FirstOrDefault
					(
						p =>
						{
							var spParamAttributeWithPrimaryKey
								= p.GetCustomAttributes<DbColumnAttribute> ()
									.FirstOrDefault (a => a.IsPrimaryKey);

							return (spParamAttributeWithPrimaryKey != null);
						}
					);

			// Is there a primary key in the "to table" entity?
			if (toTableProperty == null)
			{
				// No.
				throw (new InvalidOperationException ("The \"to table\" entity \"" + fromTableType.Name + "\" does not have a property that is marked as \"primary key\"."));
			}

			// The "from table", and "to table", and the joining properties of the two tables have been established by now.
			// Remember them using the list.

			var join
				= new JoinInfo
					{
						JoinType = joinType
					};

			// Add the join details.
			join.JoinConditions.Add
				(
					new JoinCondition
					{
						FromColumnInfo
							= new ColumnInfo
								{
									TableEntity = fromTableType,
									ColumnProperty = fromTableProperty
								},
						ToColumnInfo
							= new ColumnInfo
								{
									TableEntity = toTableType,
									ColumnProperty = toTableProperty
								}
					}
				);

			this.fromJoins.Add (join);
		}

		/// <summary>
		/// Adds the joins started from a "from" clause.
		/// NOTE: You can mention multiple conditions in this case. The criteria to be met are:
		/// NOTE: (1) Only "&&" operator is used to link the conditions. The "||" operator, or any nested (parantheses based) conditions are not allowed.
		/// NOTE: (2) Only "==" comparison operator is used to compare the properties.
		/// </summary>
		/// <typeparam name="TFromTable">The generic entity type representing the "from table" of the join.</typeparam>
		/// <typeparam name="TToTable">The generic entity type representing the "to tbale" of the join.</typeparam>
		/// <param name="func">An expression indicating the conditions of joining between the "from" and "to" tables.</param>
		/// <param name="joinType">The join type.</param>
		private void AddFromClauseJoin<TFromTable, TToTable> (Expression<Func<TFromTable, TToTable, bool>> func, JoinType joinType)
		{
			// Get the boolean expression that contains 1 or more conditions joined together by "&&" operator.
			var joinConditions
				= func.Body
					.ToString ()
					.Replace ("(", String.Empty)
					.Replace (")", String.Empty)
					.Replace ("{", String.Empty)
					.Replace ("}", String.Empty)
					.Replace ("AndAlso", "^")
					.Split ('^')
					.ToList ();

			// For remembering the individual conditions, form a Tuple list.
			var join = new JoinInfo { JoinType = joinType };

			// Process the individual boolean conditions.
			joinConditions
				.ForEach
				(
					st =>
					{
						// Locate the == operator, and find the LHS and RHS.
						var parts
							= st.Trim ()
								.Replace ("==", "^")
								.Split ('^');

						// Is the condition in "a.PropertyOne == b.PropertyOne" format?
						if (parts.Length != 2)
						{
							// No.
							throw (new ArgumentException ("The expected format for JOIN condition is: \"a.ForeignKeyId == b.PrimaryKeyId && a.SomeColumnName == b.SomeOtherColumnName\", etc."));
						}

						var part1 = parts [0].Trim ();
						var part2 = parts [1].Trim ();

						// By processing the LHS and RHS, find out the names of the "from" and "to" properties.
						var lhsPeriodLocation = part1.IndexOf (".", StringComparison.Ordinal);
						var rhsPeriodLocation = part2.IndexOf (".", StringComparison.Ordinal);

						// Get the LHS and RHS aliases.
						var lhsAlias = part1.Substring (0, lhsPeriodLocation);
						var rhsAlias = part2.Substring (0, rhsPeriodLocation);

						// Get the corresponding tables from the registered list of aliases.
						var lhsTable = this.GetTableForAlias (lhsAlias);
						var rhsTable = this.GetTableForAlias (rhsAlias);

						var lhsPropertyName = part1.Substring (lhsPeriodLocation + 1).Trim ();
						var rhsPropertyName = part2.Substring (rhsPeriodLocation + 1).Trim ();

						// Locate the "from" entity property.
						var lhsTableProperty
							= lhsTable
								.GetProperties ()
								.FirstOrDefault (p => p.Name == lhsPropertyName);

						// Does the LHS property exist?
						if (lhsTableProperty == null)
						{
							// No.
							throw (new ParameterizedQueryException ("The property name, \"" + lhsPropertyName + "\" does not exist in entity \"" + lhsTable.Name + "\"."));
						}

						// Locate the "to" entity property.
						var rhsTableProperty
							= rhsTable
								.GetProperties ()
								.FirstOrDefault (p => p.Name == rhsPropertyName);

						// Does the RHS property exist?
						if (rhsTableProperty == null)
						{
							// No.
							throw (new ParameterizedQueryException ("The property name, \"" + rhsPropertyName + "\" does not exist in entity \"" + rhsTable.Name + "\"."));
						}

						// Add the details to the tuple list.
						join.JoinConditions.Add
							(
								new JoinCondition
								{
									FromColumnInfo
										= new ColumnInfo
											{
												TableEntity = lhsTable,
												ColumnProperty = lhsTableProperty
											},
									ToColumnInfo
										= new ColumnInfo
											{
												TableEntity = rhsTable,
												ColumnProperty = rhsTableProperty
											}
								}
							);
					}
				);

			// Now, you have the properties of all the boolean condtiions, and their corresponding table (entity) names.
			this.fromJoins.Add (join);
		}

		#endregion
	}
}