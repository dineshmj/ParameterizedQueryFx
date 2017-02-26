namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents a join condition between two tables. The expectation is that the comparisons
	/// are always "==", and always the "from" and "to" table entity properties are compared.
	/// </summary>
	public sealed class JoinCondition
	{
		#region Properties.

		/// <summary>
		/// The "from" table property from which the join condition starts.
		/// </summary>
		public ColumnInfo FromColumnInfo { get; set; }

		/// <summary>
		/// The "to" table property with which the join condition ends.
		/// </summary>
		public ColumnInfo ToColumnInfo { get; set; }

		#endregion
	}
}