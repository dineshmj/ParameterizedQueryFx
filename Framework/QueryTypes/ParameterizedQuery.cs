using System;
using System.Collections.Generic;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private instance fields.

		/// <summary>
		/// The SQL query type.
		/// </summary>
		private SqlQueryType queryType;

		#endregion

		#region Constructors.

		/// <summary>
		/// Instantiates this class.
		/// NOTE: The constructor has been made private intentionally.
		/// </summary>
		private ParameterizedSqlQuery ()
		{
			// Initialize the query.
			this.queryType = SqlQueryType.NotSetYet;

			// Prepare the lists and dictionaries.
			this.tableAliasesDictionary = new Dictionary<string, Type> ();
			this.columnsToSelect = new List<ColumnInfo> ();
			this.orderByColumns = new List<ColumnInfo> ();
			this.columnAliasesDictionary = new List<KeyValuePair<ColumnInfo, string>> ();
			this.fromJoins = new List<JoinInfo> ();
			this.sqlParameters = new List<SqlQueryParameter> ();
		}

		#endregion

		#region Static methods.

		/// <summary>
		/// Calls the private constructor, and gets an instance of this class.
		/// NOTE: Calling this method is the only way to instantiate this class.
		/// </summary>
		/// <returns></returns>
		public static ParameterizedSqlQuery New ()
		{
			return (new ParameterizedSqlQuery ());
		}

		#endregion
	}
}