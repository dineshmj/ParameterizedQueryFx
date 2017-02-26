using System.Collections.Generic;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents a JOIN clause after the FROM clause.
	/// </summary>
	public sealed class JoinInfo
	{
		#region Properties.

		/// <summary>
		/// The join type (inner, left, right, full outer, etc.)
		/// </summary>
		public JoinType JoinType { get; set; }

		/// <summary>
		/// A list of conditions that belong to a join in an SQL statement.
		/// </summary>
		public IList<JoinCondition> JoinConditions { get; }

		#endregion

		#region Constructors.

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		public JoinInfo ()
		{
			this.JoinConditions = new List<JoinCondition> ();
		}

		#endregion
	}
}