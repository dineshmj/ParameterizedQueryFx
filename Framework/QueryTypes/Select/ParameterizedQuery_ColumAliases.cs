using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
		/// A dictionary of columns vs. the aliases of the columns.
		/// </summary>
		private readonly IList<KeyValuePair<ColumnInfo, string>> columnAliasesDictionary;

		#endregion

		#region Methods.

		/// <summary>
		/// Accepts the aliases of the columns in the SELECT clause of the SQL statement.
		/// </summary>
		/// <param name="aliases">A list of alias names for the columns of the SELECT clause.</param>
		public ParameterizedSqlQuery ColumnAliasesAs (params string [] aliases)
		{
			// Do the aliases match in count with the number of columns?
			if (aliases.Length != this.columnsToSelect.Count)
			{
				// No.
				throw (new ParameterizedQueryException ("The number of aliases does not match with the count of SELECT clause columns."));
			}

			// Set each column alias.
			for (var i = 0; i < aliases.Length; i++)
			{
				// Get the corresponding column.
				var matchingColumn = this.columnsToSelect [i];

				// Is it a NULL column and the alias not specified?
				if (matchingColumn == null && String.IsNullOrEmpty (aliases [i]))
				{
					// Yes.
					throw (new ParameterizedQueryException ("A NULL column mentioned in the SELECT clause must have a valid alias specified."));
				}

				// Is it a valid alias?
				if (String.IsNullOrEmpty (aliases [i]) == false)
				{
					// Yes.
					this.columnAliasesDictionary.Add (new KeyValuePair<ColumnInfo, string> (matchingColumn, aliases [i]));
				}
			}

			return (this);
		}

		#endregion
	}
}