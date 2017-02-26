using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using ParameterizedQuery.Framework.Entities;
using ParameterizedQuery.Framework.Extensions;

// ReSharper disable CheckNamespace
// ReSharper disable ClassCannotBeInstantiated

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private readonly instance fields.

		/// <summary>
		/// The compound boolean expression (with several AND and OR conditions together) representing
		/// the entire WHERE clause of the SQL statement.
		/// </summary>
		private BinaryExpression whereConditionBinaryExpression;

		/// <summary>
		/// The T-SQL parameters of the SQL statement.
		/// </summary>
		private readonly IList<SqlQueryParameter> sqlParameters;

		/// <summary>
		/// This would be used only if there is only one condition, and it is a ".in ()" or
		/// ".NotIn ()" condition.
		/// </summary>
		private Expression inOrNotInExpression;

		#endregion

		#region The "Where" methods.

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1>
			(
				Expression<Func<T1, bool>> f1
			)
			where T1 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2>
			(
				Expression<Func<T1, T2, bool>> f1
			)
			where T1 : new()
			where T2 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3>
			(
				Expression<Func<T1, T2, T3, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4>
			(
				Expression<Func<T1, T2, T3, T4, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
		{
			// Process the binary expression.
			var funcBody = f1.Body as BinaryExpression;

			if (funcBody != null)
			{
				this.whereConditionBinaryExpression = funcBody;
			}
			else
			{
				// There is only one condition, and that too is either a ".In () " or ".NotIn ()" call.
				this.inOrNotInExpression = f1.Body;
			}

			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5>
			(
				Expression<Func<T1, T2, T3, T4, T5, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8, T9>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <typeparam name="T13">The generic entity type representing the thirteenth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
			where T13 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <typeparam name="T13">The generic entity type representing the thirteenth DB table.</typeparam>
		/// <typeparam name="T14">The generic entity type representing the fourteenth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
			where T13 : new()
			where T14 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		/// <summary>
		/// Accepts the WHERE clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <typeparam name="T13">The generic entity type representing the thirteenth DB table.</typeparam>
		/// <typeparam name="T14">The generic entity type representing the fourteenth DB table.</typeparam>
		/// <typeparam name="T15">The generic entity type representing the fifteenth DB table.</typeparam>
		/// <param name="f1">A func that returns a compound boolean expression representing the WHERE clause conditions.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Where<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
			(
				Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, bool>> f1
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
			where T13 : new()
			where T14 : new()
			where T15 : new()
		{
			// Process the binary expression.
			this.whereConditionBinaryExpression = ((BinaryExpression) f1.Body);
			return (this);
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Processes the C# expression with multiple conditions representing the
		/// WHERE clause conditions of the SQL statement.
		/// </summary>
		private string ProcessWhereConditionBinaryExpression ()
		{
			var builder = new StringBuilder ();
			var indent = 1;

			// Prepare the hierarchically and recursively organized bound logical expressions.
			var whereClauseConditions = (new BoundLogicalExpression (LogicalOperator.None, this.whereConditionBinaryExpression ?? this.inOrNotInExpression)).SubExpressions;

			// Add the individual root-node binary expressions.
			foreach (var oneExpression in whereClauseConditions)
			{
				// Process each sub-condition(s) in the compound boolean expression.
				this.PrepareWhereClauseText (builder, oneExpression, ref indent);
			}

			return (builder.ToString ());
		}

		/// <summary>
		/// Builds the complete T-SQL statement by processing the SELECT, FROM, WHERE parts of the query.
		/// </summary>
		/// <param name="builder">The string builder to use.</param>
		/// <param name="ble">The bound logical expression.</param>
		/// <param name="indent">The indent count.</param>
		private void PrepareWhereClauseText
			(
				StringBuilder builder,
				BoundLogicalExpression ble,
				ref int indent
			)
		{
			var andedOrOredCondition = false;

			// Add indent.
			this.AddIndent (builder, indent);

			// Add the logical operator binding two conditions.
			switch (ble.LogicalOperator)
			{
				// And.
				case LogicalOperator.And:
					andedOrOredCondition = true;
					builder.Append ("and ");
					break;

				// Or.
				case LogicalOperator.Or:
					andedOrOredCondition = true;
					builder.Append ("or ");
					break;
			}

			// Are there sub-conditions?
			if (ble.SubExpressions.Count <= 1)
			{
				// No, just one. Add the condition's text.
				builder.Append (this.GetTextOf (ble.LogicalExpression));
				builder.AppendLine ();
			}
			else
			{
				// There are sub-conditions.

				// Was "and" or "or" added?
				if (andedOrOredCondition)
				{
					// Yes. Begin the compound conditions with
					// a new line, and an opening parenthesis
					builder.AppendLine ();
					this.AddIndent (builder, indent);
				}

				builder.Append ("(");                   // Style		(
				builder.AppendLine ();                  //					t.ColumnName
				indent++;

				// Process each sub-expression.
				foreach (var oneSubExp in ble.SubExpressions)
				{
					this.PrepareWhereClauseText (builder, oneSubExp, ref indent);
				}

				indent--;
				this.AddIndent (builder, indent);

				// Close the opening parenthesis.
				builder.Append (")");
				builder.AppendLine ();
			}
		}

		/// <summary>
		/// Gets the text of the specified binary expression.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		private string GetTextOf (Expression expression)
		{
			var builder = new StringBuilder ();
			var expressionText
				= expression
					.ToString ()
					.Replace ("(", String.Empty)
					.Replace (")", String.Empty);

			// Is it a " is " statement?
			if (expression.NodeType == ExpressionType.TypeIs)
			{
				return (this.HandleIsNullCondition (expressionText));
			}

			// Is it a " like " operator based call?
			if
				(
					expression.NodeType == ExpressionType.Call
					&&
					(
						expressionText.IndexOf (".StartsWith", StringComparison.Ordinal) != -1
						|| expressionText.IndexOf (".EndsWith", StringComparison.Ordinal) != -1
						|| expressionText.IndexOf (".Like", StringComparison.Ordinal) != -1
						|| expressionText.IndexOf (".NotLike", StringComparison.Ordinal) != -1
					)
				)
			{
				return (this.HandleStartsWithEndsWithLikeOrNotLikeCalls (expression));
			}

			// Is it an " in " call?
			if (expression.NodeType == ExpressionType.Call)
			{
				return (this.HandleInCall (expression));
			}

			SqlQueryParameter leftSqlQueryParameter = null, rightSqlQueryParameter = null;
			Type leftPropertyType, rightPropertyType;
			PropertyInfo leftPropertyInfo, rightPropertyInfo;

			// Get a binary expression.
			var binaryExpression = (BinaryExpression) expression;

			// Get the left part.
			var leftPart = binaryExpression.Left;
			var rightPart = binaryExpression.Right;

			// Get the individual left and right part types.
			var leftType = leftPart.NodeType;
			var rightType = rightPart.NodeType;

			string leftPropertyText, rightPropertyText;

			// Is there a property expression on the left side?
			if (this.IsPropertyPartExtractbleFromExpression (leftPart, out leftPropertyInfo, out leftPropertyText, out leftPropertyType) == false)
			{
				// The left part of the expression does not contain a property name.

				string leftLocalVariableName;
				object leftLocalVariableValue;
				Type leftLocalVariableType;

				if (this.AreLocalVariableDetailsExtractable (leftPart, out leftLocalVariableName, out leftLocalVariableValue, out leftLocalVariableType, out leftSqlQueryParameter))
				{
					// Left side is a variable.
				}
			}

			// Is there a property expression on the right side?
			if (this.IsPropertyPartExtractbleFromExpression (rightPart, out rightPropertyInfo, out rightPropertyText, out rightPropertyType) == false)
			{
				// The left part of the expression does not contain a property name.

				string rightLocalVariableName;
				object rightLocalVariableValue;
				Type rightLocalVariableType;

				if (this.AreLocalVariableDetailsExtractable (rightPart, out rightLocalVariableName, out rightLocalVariableValue, out rightLocalVariableType, out rightSqlQueryParameter))
				{
					// Right side is a variable.
				}
			}

			// Get the logical operator.
			var op = binaryExpression.NodeType;
			var temporaryBuilder = new StringBuilder ();
			var variableUsedIsNullAndConditionToBeIgnored = false;

			// Process the left side of the boolean expression.
			switch (leftType)
			{
				// Property access, or variable name usage. Example: "c.Grade", local variable "searchName", etc.
				case ExpressionType.MemberAccess:
					// Is it a local variable usage?
					if (leftSqlQueryParameter != null)
					{
						// Yes. Use the corresponding SQL query parameter.
						temporaryBuilder.Append (leftSqlQueryParameter.Name);
						this.AddToSqlQueryParameters (leftSqlQueryParameter);
					}
					else
					{
						// No, it is just a property access (like, "c.Grade").
						temporaryBuilder.Append (leftPropertyText);
					}
					break;

				// Usage of constants. Example: 1, 2, 3, "A", "B", "C", etc.
				case ExpressionType.Constant:
				case ExpressionType.New:
					var leftText = leftPart.ToString ();

					// Is it a hard-coded date?
					if (leftText.IndexOf ("new DateTime", StringComparison.Ordinal) != -1)
					{
						// Yes.
						// https://msdn.microsoft.com/en-us/library/bb361179%28v=vs.110%29.aspx
						this.ExtractHardCodedDateFromLocalVariable (rightPart, out leftSqlQueryParameter);
					}

					// Process the left side hard-coded date or constant value.
					this.PrepareTextForLeftOrRightSide (rightPropertyType, temporaryBuilder, leftText, leftSqlQueryParameter);
					break;
			}

			// Handle logical operator in the boolean expression (such as, "==", ">=", etc.)
			this.HandleLogicalOperator (op, temporaryBuilder);

			// Handle the right side of the boolean expression.
			switch (rightType)
			{
				// Property access, or variable name usage. Example: "c.Grade", local variable "searchName", etc.
				case ExpressionType.MemberAccess:
					// Is it a local variable usage?
					if (rightSqlQueryParameter != null)
					{
						// Yes. Use the corresponding SQL query parameter.
						temporaryBuilder.Append (rightSqlQueryParameter.Name);
						this.AddToSqlQueryParameters (rightSqlQueryParameter);
					}
					else
					{
						// No, it is just a property access (like, "c.Grade"), or a variable being referenced.
						if (String.IsNullOrEmpty (rightPropertyText) == false)
						{
							// There is either a property name reference, or a variable used with some value in it.
							temporaryBuilder.Append (rightPropertyText);
						}
						else
						{
							// The referenced variable is NULL. Ignore this condition, and don't add to collection.
							variableUsedIsNullAndConditionToBeIgnored = true;
						}
					}
					break;

				case ExpressionType.Constant:
				case ExpressionType.New:
					var rightText = rightPart.ToString ();

					// Is it a hard-coded date?
					if (rightText.IndexOf ("new DateTime", StringComparison.Ordinal) != -1)
					{
						// Yes.
						// https://msdn.microsoft.com/en-us/library/bb361179%28v=vs.110%29.aspx
						this.ExtractHardCodedDateFromLocalVariable (rightPart, out rightSqlQueryParameter);
					}

					// Process the right side hard-coded date or constant value.
					this.PrepareTextForLeftOrRightSide (leftPropertyType, temporaryBuilder, rightText, rightSqlQueryParameter);
					break;
			}

			// Is the variable used is NULL, and hence the comparison condition is NOT TO BE added?
			if (variableUsedIsNullAndConditionToBeIgnored)
			{
				// Yes.
				builder.Append (ALWAYS_TRUE_CONDITION);
			}
			else
			{
				// No, the condition is a valid one. Add it to the set.
				builder.Append (temporaryBuilder);
			}

			// Return the T-SQL equivalent of the binary expression.
			return (builder.ToString ());
		}
		
		/// <summary>
		/// Prepares the expression text corresponding to the specified side of the 
		/// boolean expression.
		/// </summary>
		/// <param name="oppositeSidePropertyType">The property type of the opposite side of the boolean expression.</param>
		/// <param name="builder">The string builder/</param>
		/// <param name="theOtherSideText">The requested side text of the expression.</param>
		/// <param name="theOtherSideSqlQueryParameter">A T-SQL query parameter prepared for the side in question.</param>
		private void PrepareTextForLeftOrRightSide
			(
				Type oppositeSidePropertyType,
				StringBuilder builder,
				string theOtherSideText,
				SqlQueryParameter theOtherSideSqlQueryParameter
			)
		{
			// Get the opposite side's property's type.
			if (oppositeSidePropertyType != null)
			{
				// Is it a number?
				if (oppositeSidePropertyType.IsNumber ())
				{
					// Yes.
					builder.Append (theOtherSideText);
				}
				// Is it text?
				else if (oppositeSidePropertyType.IsText ())
				{
					// Yes. Prepare a T-SQL parameter, and add it to the query text.
					var sqlParameter = new SqlQueryParameter (theOtherSideText.Replace ("\"", String.Empty), SqlDbType.NVarChar);
					this.AddToSqlQueryParameters (sqlParameter);
					builder.Append (sqlParameter.Name);
				}
				// Is it a date-time?
				else if (oppositeSidePropertyType == typeof (DateTime))
				{
					// Is a T-SQL parameter already created for the other side?
					if (theOtherSideSqlQueryParameter != null)
					{
						// Yes.
						builder.Append ("convert (datetime, '");
						builder.Append (theOtherSideSqlQueryParameter.Value);
						builder.Append ("', 106)");
					}
					else
					{
						// No. Just use the specified text for the date's value.
						builder.Append ("convert (datetime, '");
						builder.Append (theOtherSideText.Replace ("\"", String.Empty));
						builder.Append ("', 106)");
					}
				}
			}
		}
		
		/// <summary>
		/// Handles the logical operator.
		/// </summary>
		/// <param name="logicOp">The logical operator.</param>
		/// <param name="builder">The string builder.</param>
		private void HandleLogicalOperator (ExpressionType logicOp, StringBuilder builder)
		{
			switch (logicOp)
			{
				case ExpressionType.Equal:
					builder.Append (" = ");
					break;

				case ExpressionType.NotEqual:
					builder.Append (" != ");
					break;

				case ExpressionType.GreaterThan:
					builder.Append (" > ");
					break;

				case ExpressionType.GreaterThanOrEqual:
					builder.Append (" >= ");
					break;

				case ExpressionType.LessThan:
					builder.Append (" < ");
					break;

				case ExpressionType.LessThanOrEqual:
					builder.Append (" <= ");
					break;

				case ExpressionType.MemberAccess:
					break;
			}
		}

		#endregion
	}
}