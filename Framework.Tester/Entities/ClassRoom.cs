using System.Data;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.Tester.Entities
{
	/// <summary>
	/// Represents a class room in a school.
	/// </summary>
	[DbTable ("PQ_ClassRoom")]
	public sealed class ClassRoom
	{
		#region Properties.

		/// <summary>
		/// The unique ID of the class room.
		/// </summary>
		[DbColumn ("class_room_id", SqlDbType.NVarChar, true)]
		public int Id { get; set; }

		/// <summary>
		/// The grade of the class room.
		/// </summary>
		[DbColumn ("grade_number", SqlDbType.Int, false)]
		public int Grade { get; set; }

		/// <summary>
		/// The division of the class room.
		/// </summary>
		[DbColumn ("class_division", SqlDbType.NVarChar, false)]
		public string Division { get; set; }

		#endregion
	}
}