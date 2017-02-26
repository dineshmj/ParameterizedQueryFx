using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

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
		#region Private methods.

		/// <summary>
		/// Builds a parameterized SELECT T-SQL query command.
		/// </summary>
		/// <returns></returns>
		private SqlCommand BuildParameterizedSelectCommand ()
		{
			// Get the parameterized SQL text.
			var parameterizedSqlText = this.BuildSelectSqlStatement ();

			// Extracts the lines.
			var individualLines = parameterizedSqlText.Replace ("\r", String.Empty).Split ('\n').ToList ();
			var newSqlStatementLines = new List<string> ();

			// Walk through each line.
			foreach (var oneLine in individualLines)
			{
				var trimmedLine = oneLine.Trim ().Replace ("\t", String.Empty);

				// Does it contain the "1 == 1" condition?
				if
					(
						trimmedLine != ALWAYS_TRUE_CONDITION
						&& trimmedLine != ("and " + ALWAYS_TRUE_CONDITION)
						&& trimmedLine != ("or " + ALWAYS_TRUE_CONDITION)
					)
				{
					// No. Remove it.
					newSqlStatementLines.Add (oneLine);
				}
			}

			List<string> finalSqlLines = null;

			for (var j = 0; j < 15; j++)
			{
				finalSqlLines = new List<string> ();

				for (var i = 0; i < newSqlStatementLines.Count; i++)
				{
					if (i < newSqlStatementLines.Count - 2)
					{
						var thisLine = newSqlStatementLines [i].Trim ().Replace ("\t", String.Empty);
						var nextLine = newSqlStatementLines [i + 1].Trim ().Replace ("\t", String.Empty);

						if (thisLine == "(" && nextLine == ")")
						{
							i++;
							if
								(
									i + 1 < newSqlStatementLines.Count - 2
									&&
									(
										newSqlStatementLines [i + 1].Replace ("\t", String.Empty).StartsWith ("and ")
										|| newSqlStatementLines [i + 1].Replace ("\t", String.Empty).StartsWith ("or ")
									)
								)
							{
								newSqlStatementLines [i + 1]
									= newSqlStatementLines [i + 1]
										.Replace ("\tand", "\t")
										.Replace ("\tor", "\t")
										.Replace ("\t ", "\t");
							}

							continue;
						}
					}

					finalSqlLines.Add (newSqlStatementLines [i]);
				}

				newSqlStatementLines = finalSqlLines;
			}

			parameterizedSqlText = String.Join ("\r\n", finalSqlLines);

			// Build a T-SQL command.
			var parameterizedSelectCommand = new SqlCommand (parameterizedSqlText);

			// Add the T-SQL parameters.
			foreach (var oneQueryParameter in this.sqlParameters)
			{
				parameterizedSelectCommand
					.Parameters
						.Add (oneQueryParameter.Name, oneQueryParameter.DbType).Value       // The T-SQL parameter.
							= oneQueryParameter.Value;                                      // Value of the T-SQL parameter.
			}

			return (parameterizedSelectCommand);
		}

		/// <summary>
		/// Builds the SELECT SQL statement.
		/// </summary>
		/// <returns></returns>
		private string BuildSelectSqlStatement ()
		{
			var builder = new StringBuilder ();

			// Add the SELECT keyword.
			builder.AppendLine ("select");

			// Add the column names.
			this.AddColumnNamesToSelectSqlStatement (builder);

			// Add the FROM clause.
			builder.AppendLine ("from");
			builder.Append ("\t");
			builder.Append (this.GetDbTableNameOf (this.fromEntityType));
			builder.Append (" as ");
			builder.AppendLine (this.GetAliasForTable (this.fromEntityType));

			// Add the joins.
			this.AddJoinsToTheFromClause (builder);

			// Add the WHERE clause.
			this.AddWhereClause (builder);

			// Add order by clause.
			this.AddOrderByClause (builder);

			// Return the SQL statement.
			return (builder.ToString ());
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Adds the column names to the SELECT SQL statement.
		/// </summary>
		/// <param name="builder">The string builder to use.</param>
		private void AddColumnNamesToSelectSqlStatement (StringBuilder builder)
		{
			var selectColumnsCounter = 0;

			if (this.selectClauseDistinct)
			{
				builder.Append ("\tdistinct");
				builder.AppendLine ();
			}

			var paddingTuples = new List<Tuple<ColumnInfo, int>> ();

			this.columnsToSelect
				.ToList ()
				.ForEach
				(
					c =>
					{
						// Is it a "null" column, represented by "Null.AsColumn"?
						if (c == null)
						{
							// Yes.
							paddingTuples.Add (new Tuple<ColumnInfo, int> (c, 15));
							return;
						}

						var totalChars
							= c.IsLocalVariable
							?
							(
								c.SqlParameterForLocalVariable.Name.Length
								+ 4
							)
							:
							(
								this.GetAliasForTable (c.TableEntity).Length
								+ 1
								+ this.GetDbColumnNameOf (c.ColumnProperty).Length
								+ 4
								);

						paddingTuples.Add (new Tuple<ColumnInfo, int> (c, totalChars));
					}
				);

			var maxColumnCharWidthWithPadding = paddingTuples.Max (pt => pt.Item2);

			// Find out the width of the largest named column + 4 characters.
			for (var i = 10; i < 1000; i = i + 10)
			{
				if (i > maxColumnCharWidthWithPadding)
				{
					maxColumnCharWidthWithPadding = i + 2;
					break;
				}
			}

			var nullColumnsHandledSoFar = 0;
			var columnsLoopCounter = -1;

			// Add the columns to the SELECT clause.
			foreach (var oneColumn in this.columnsToSelect)
			{
				string columnAlias;

				columnsLoopCounter++;
				var continueColumnLoop = false;

				// Is it a "Null.AsColumn" column in the SELECT clause?
				if (oneColumn == null)
				{
					// Yes.
					var locallyHandledNullColumnsCounter = 0;

					// Iterate, and find out the paddingTuples to get the padding length (if there are two or more NULL columns
					// with different alias names, the padding length would accordingly be different.
					foreach (var oneTuple in paddingTuples)
					{
						// Is it a NULL column?
						if (oneTuple.Item1 == null)
						{
							// Yes. If the current NULL column is not this, continue.
							if (locallyHandledNullColumnsCounter < nullColumnsHandledSoFar)
							{
								locallyHandledNullColumnsCounter++;
								continue;
							}

							var nullColumnFoundCounter = 0;

							// Locate the index, and take alias corresponding to that index from the column aliases dictionary.
							foreach (var onePair in this.columnAliasesDictionary)
							{
								// Is it a "null" column?
								if (onePair.Key == null)
								{
									// 
									nullColumnFoundCounter++;
								}

								if (nullColumnFoundCounter < locallyHandledNullColumnsCounter)
								{
									continue;
								}

								// Is it the same index as the FOREACH counter?
								if (nullColumnFoundCounter > locallyHandledNullColumnsCounter)
								{
									// Yes. 
									columnAlias = onePair.Value;
									selectColumnsCounter++;

									// Consider this NULL column as having processed.
									nullColumnsHandledSoFar++;

									builder.Append ("\tnull");

									// Add padding spaces.
									var paddingCount = maxColumnCharWidthWithPadding - 7;		// TODO: Number 7 is hard-coded.
									for (var i = 0; i < paddingCount; i++)
									{
										builder.Append (" ");
									}

									// Add the alias.
									builder.Append ("as ");
									builder.Append (columnAlias);

									// If it is not the last column, add the comma.
									if (columnsLoopCounter < this.columnsToSelect.Count - 1)
									{
										builder.Append (",");
									}

									builder.AppendLine ();

									continueColumnLoop = true;
									break;
								}
							}
						}

						if (continueColumnLoop)
						{
							break;
						}
					}

					if (continueColumnLoop)
					{
						continue;
					}
				}

				// The current column is NOT a null column.
				var padSpaceCharactersCount
					// ReSharper disable once PossibleNullReferenceException
					= maxColumnCharWidthWithPadding - paddingTuples.FirstOrDefault (pt => pt.Item1 == oneColumn).Item2;

				selectColumnsCounter++;

				var columnAliasKeyValuePar = this.columnAliasesDictionary.FirstOrDefault (kvp => kvp.Key == oneColumn);

				// Get the column alias.
				columnAlias = columnAliasKeyValuePar.Value;

				// Get the table alias.
				var tableAlias = this.GetAliasForTable (oneColumn.TableEntity);

				// Add the alias and table name.
				builder.Append ("\t");

				// Is it a local variable, instead of a entity property?
				if (oneColumn.IsLocalVariable)
				{
					// Yes. Print the name of the T-SQL parameter.
					builder.Append (oneColumn.SqlParameterForLocalVariable.Name);
				}
				else
				{
					builder.Append (tableAlias);
					builder.Append (".");
					builder.Append (this.GetDbColumnNameOf (oneColumn.ColumnProperty));
				}

				// Is there a column alias?
				if (String.IsNullOrEmpty (columnAlias) == false)
				{
					// Yes. Add it.
					for (var i = 0; i < padSpaceCharactersCount; i++)
					{
						builder.Append (" ");
					}

					builder.Append (" as ");
					builder.Append (columnAlias);
				}

				// Add a comma, unless it is the last column.
				if (selectColumnsCounter < this.columnsToSelect.Count)
				{
					builder.AppendLine (",");
				}
				else
				{
					builder.AppendLine ();
				}
			}
		}

		/// <summary>
		/// Add the joins with the FROM clause of the SQL statement.
		/// </summary>
		/// <param name="builder">The string builder to use.</param>
		private void AddJoinsToTheFromClause (StringBuilder builder)
		{
			// Add each join.
			foreach (var oneJoin in this.fromJoins)
			{
				builder.Append ("\t\t");

				// Add the join type.
				switch (oneJoin.JoinType)
				{
					case JoinType.InnerJoin:
						builder.Append ("inner join ");
						break;

					case JoinType.LeftJoin:
						builder.Append ("left join ");
						break;

					case JoinType.RightJoin:
						builder.Append ("right join ");
						break;

					case JoinType.FullOuterJoin:
						builder.Append ("full outer join ");
						break;
				}

				var counter = 0;

				// Add each join condition.
				foreach (var oneCondition in oneJoin.JoinConditions)
				{
					counter++;

					var fromTableAlias = this.GetAliasForTable (oneCondition.FromColumnInfo.TableEntity);
					var toTableAlias = this.GetAliasForTable (oneCondition.ToColumnInfo.TableEntity);

					if (counter == 1)
					{
						builder.Append (this.GetDbTableNameOf (oneCondition.ToColumnInfo.TableEntity));        // The "to" table (item 3 of the tuple).
						builder.Append (" as ");
						builder.Append (toTableAlias);
						builder.AppendLine (" on");
						builder.Append ("\t\t\t");
					}
					else
					{
						builder.Append ("\t\t\tand ");
					}

					builder.Append (fromTableAlias);
					builder.Append (".");
					builder.Append (this.GetDbColumnNameOf (oneCondition.FromColumnInfo.ColumnProperty));       // The "from table" property.
					builder.Append (" = ");
					builder.Append (toTableAlias);
					builder.Append (".");
					builder.AppendLine (this.GetDbColumnNameOf (oneCondition.ToColumnInfo.ColumnProperty));   // The "to table" property.
				}
			}
		}

		/// <summary>
		/// Adds the WHERE clause to the SQL statement.
		/// </summary>
		/// <param name="builder">The string builder to use.</param>
		private void AddWhereClause (StringBuilder builder)
		{
			// Add the WHERE keyword.
			builder.AppendLine ("where");
			builder.Append (this.ProcessWhereConditionBinaryExpression ());
		}

		/// <summary>
		/// Adds the T-SQL parameter variable definition and setting of values part
		/// to make a completely runnable T-SQL script.
		/// </summary>
		/// <returns></returns>
		private string AddSqlParametersDefinition ()
		{
			var builder = new StringBuilder ();

			// Add the declarations for the parameters.
			foreach (var oneSqlParameter in this.sqlParameters)
			{
				// "declare" keyword.
				builder.Append ("declare ");
				builder.Append (oneSqlParameter.Name);
				builder.Append (" ");

				// Data type.
				switch (oneSqlParameter.DbType)
				{
					// Numeric.
					case SqlDbType.BigInt:
						builder.Append ("bigint");
						break;

					// Char / nChar
					case SqlDbType.Char:
					case SqlDbType.NChar:
						builder.Append ("nchar");
						break;

					// Varchar.
					case SqlDbType.NVarChar:
						builder.Append ("nvarchar (300)");
						break;

					// Date time.
					case SqlDbType.DateTime:
						builder.Append ("datetime");
						break;
				}

				builder.AppendLine ();
			}

			builder.AppendLine ();

			// Add the assignment statements.
			foreach (var oneSqlParameter in this.sqlParameters)
			{
				// "select" keyword for assignment.
				builder.Append ("select ");
				builder.Append (oneSqlParameter.Name);
				builder.Append (" = ");

				// Add the value.
				switch (oneSqlParameter.DbType)
				{
					// Numeric.
					case SqlDbType.BigInt:
						builder.Append (oneSqlParameter.Value);
						break;

					// Char / nVarChar.
					case SqlDbType.Char:
					case SqlDbType.NChar:
					case SqlDbType.NVarChar:
						builder.Append ("'");
						builder.Append (oneSqlParameter.Value);
						builder.Append ("'");
						break;

					// Date time.
					case SqlDbType.DateTime:
						builder.Append ("convert (datetime, '");
						builder.Append (oneSqlParameter.Value);
						builder.Append ("', 106)");

						break;
				}

				builder.AppendLine ();
			}

			builder.AppendLine ();
			return (builder.ToString ());
		}

		#endregion
	}
}