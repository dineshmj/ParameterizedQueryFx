namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents the types of SQL statements.
	/// </summary>
	public enum SqlQueryType
	{
		#region Literals.

		/// <summary>
		/// Indicates that the query type hasn't been ascertained yet.
		/// </summary>
		NotSetYet,

		/// <summary>
		/// The SELECT type SQL query statement.
		/// </summary>
		Select,

		/// <summary>
		/// The INSERT type SQL query statement.
		/// </summary>
		Insert,

		/// <summary>
		/// The UPDATE type SQL query statement.
		/// </summary>
		Update,

		/// <summary>
		/// The DELETE type SQL query statement.
		/// </summary>
		Delete

		#endregion
	}
}