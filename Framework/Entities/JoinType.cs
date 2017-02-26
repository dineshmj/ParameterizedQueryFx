namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents the type of joins between tables.
	/// </summary>
	public enum JoinType
	{
		#region Literals.

		/// <summary>
		/// The inner join.
		/// </summary>
		InnerJoin,

		/// <summary>
		/// The left join.
		/// </summary>
		LeftJoin,

		/// <summary>
		/// The right join.
		/// </summary>
		RightJoin,

		/// <summary>
		/// The full-outer join.
		/// </summary>
		FullOuterJoin

		#endregion
	}
}