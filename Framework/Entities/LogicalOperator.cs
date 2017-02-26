namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents the logical operators.
	/// </summary>
	public enum LogicalOperator
	{
		#region Literals.

		/// <summary>
		/// Represents the absence of any logical operator - for example,
		/// the first condition in a set of conditions would not be bound to any
		/// previous condition.
		/// </summary>
		None,

		/// <summary>
		/// The logical "and" operator.
		/// </summary>
		And,

		/// <summary>
		/// The logical "or" operator.
		/// </summary>
		Or

		#endregion
	}
}