using System.Data;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.Tester.Entities
{
	/// <summary>
	/// Represents a teacher.
	/// </summary>
	[DbTable ("PQ_Teacher")]
	public sealed class Teacher
		: PersonBase
	{
		#region Properties.

		/// <summary>
		/// The unique ID of the teacher.
		/// </summary>
		[DbColumn ("teacher_id", SqlDbType.Int, true)]
		public int Id { get; set; }

		#endregion
	}
}