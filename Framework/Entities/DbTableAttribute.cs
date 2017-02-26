using System;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Helps add a tag indicating the table name that is used to persist a given entity type.
	/// </summary>
	public sealed class DbTableAttribute
		: Attribute
	{
		#region Properties.

		/// <summary>
		/// Gets or sets the database table name.
		/// </summary>
		public string DbDbTableName { get; set; }

		/// <summary>
		/// Gets or sets the T-SQL query text for selecting entity records.
		/// </summary>
		public string SelectQueryText { get; set; }

		/// <summary>
		/// Gets or sets the T-SQL query text for selecting the count of entity records.
		/// </summary>
		public string SelectCountQueryText { get; set; }

		/// <summary>
		/// Gets or sets the T-SQL query text for inserting entity records.
		/// </summary>
		public string InsertQueryText { get; set; }
		/// <summary>
		/// Gets or sets the T-SQL query text for updating entity records.
		/// </summary>
		public string UpdateQueryText { get; set; }

		/// <summary>
		/// Gets or sets the T-SQL query text for deleting entity records.
		/// </summary>
		public string DeleteQueryText { get; set; }

		#endregion

		#region Constructors.

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="dbTableName"></param>
		/// <param name="selectQueryText">The T-SQL query text for selecting entity records.</param>
		/// <param name="selectCountQueryText">The T-SQL query text for selecting the count of entity records.</param>
		/// <param name="insertQueryText">The T-SQL query text for inserting entity records.</param>
		/// <param name="updateQueryText">The T-SQL query text for updating entity records.</param>
		/// <param name="deleteQueryText">The T-SQL query text for deleting entity records.</param>
		public DbTableAttribute
			(
				string dbTableName,
				string selectQueryText = "",
				string selectCountQueryText = "",
				string insertQueryText = "",
				string updateQueryText = "",
				string deleteQueryText = ""
			)
		{
			// Set the instance fields with the values specified.
			this.DbDbTableName = dbTableName;
			this.SelectQueryText = selectQueryText;
			this.SelectCountQueryText = selectCountQueryText;
			this.InsertQueryText = insertQueryText;
			this.UpdateQueryText = updateQueryText;
			this.DeleteQueryText = deleteQueryText;
		}

		#endregion
	}
}