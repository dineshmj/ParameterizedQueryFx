using System;
using System.Reflection;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents a column in a clause (SELECT, WHERE, etc.) of a SQL statement.
	/// </summary>
	public sealed class ColumnInfo
	{
		#region Properties.

		/// <summary>
		/// Indicates if a table and its column (i.e., an entity and its property) is not available,
		/// as the user used a local variable instead.
		/// </summary>
		public bool IsLocalVariable { get; set; }

		/// <summary>
		/// The SQL query parameter to be used, as the Table and Column entity values aren't available.
		/// </summary>
		public SqlQueryParameter SqlParameterForLocalVariable { get; set; }

		/// <summary>
		/// The table entity whose property would represent the column.
		/// </summary>
		public Type TableEntity { get; set; }

		/// <summary>
		/// The property of the table entity that would represent the column.
		/// </summary>
		public PropertyInfo ColumnProperty { get; set; }

		#endregion
	}
}