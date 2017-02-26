using System;
using System.Data;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// An attribute that specifies the corresponding DB column name for the entity specified.
	/// </summary>
	public sealed class DbColumnAttribute
		: Attribute
	{
		#region Properties.

		/// <summary>
		/// The name of the corresponding DB column.
		/// </summary>
		public string DbColumnName { get; set; }

		/// <summary>
		/// The T-SQL data type of the corresponding DB column.
		/// </summary>
		public SqlDbType DbDataType { get; set; }

		/// <summary>
		/// Indicates if the column is a primary key.
		/// </summary>
		public bool IsPrimaryKey { get; set; }

		#endregion

		#region Constructors.

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="columnName">The column name.</param>
		/// <param name="datatype">The SQL data type.</param>
		/// <param name="isPrimaryKey">Indicates if the column is a (one of the) primary key(s).</param>
		public DbColumnAttribute
			(
				string columnName,
				SqlDbType datatype,
				bool isPrimaryKey = false
			)
		{
			// Set the properties with the values specified.
			this.DbColumnName = columnName;
			this.DbDataType = datatype;
			this.IsPrimaryKey = isPrimaryKey;
		}

		#endregion
	}
}
