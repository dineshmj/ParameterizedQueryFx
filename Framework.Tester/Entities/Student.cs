using System.Data;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.Tester.Entities
{
	/// <summary>
	/// Represents a student.
	/// </summary>
	[DbTable ("PQ_Student")]
	public sealed class Student
		: PersonBase
	{
		#region Properties.

		/// <summary>
		/// The unique ID of the student.
		/// </summary>
		[DbColumn ("student_id", SqlDbType.Int, true)]
		public int Id { get; set; }

		/// <summary>
		/// The unique ID of the class to which the student belongs.
		/// </summary>
		[DbColumn ("class_room_id", SqlDbType.NVarChar, false)]
		public int ClassRoomId { get; set; }

		#endregion
	}
}