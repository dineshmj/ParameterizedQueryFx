namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents an operator in an SQL query WHERE conditions.
	/// </summary>
	public enum ComparisonOperator
	{
		#region Literals.

		/// <summary>
		/// Represents "=".
		/// </summary>
		EqualTo,

		/// <summary>
		/// Represents "!=".
		/// </summary>
		NotEqualTo,

		/// <summary>
		/// Represents ">".
		/// </summary>
		GreaterThan,

		/// <summary>
		/// Represents ">=".
		/// </summary>
		GreaterThanOrEqualTo,

		/// <summary>
		/// Represents "&lt;".
		/// </summary>
		Lessthan,

		/// <summary>
		/// Represents "&lt;=".
		/// </summary>
		LessThanOrEqualTo,

		/// <summary>
		/// Represents "in" operator to compare with a list.
		/// </summary>
		In,

		/// <summary>
		/// Represents "not in" operator to compare with a list.
		/// </summary>
		NotIn,

		/// <summary>
		/// Represents the "is null" comparison.
		/// </summary>
		IsNullComparison,

		/// <summary>
		/// Represents the "is not null" comparison.
		/// </summary>
		IsNotNullComparison

		#endregion
	}
}