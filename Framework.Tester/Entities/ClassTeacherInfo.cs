using System.Data;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.Tester.Entities
{
	/// <summary>
	/// Represents the association of a class room with the teacher who is responsible
	/// for that class room.
	/// </summary>
	[DbTable ("PQ_ClassTeacherInfo")]
	public sealed class ClassTeacherInfo
		: PersonBase
	{
		#region Properties.

		/// <summary>
		/// The unique ID of the class room.
		/// </summary>
		[DbColumn ("class_room_id", SqlDbType.NVarChar, true)]
		public int ClassRoomId { get; set; }

		/// <summary>
		/// The unique ID of the teacher who owns the responsibility of the class room.
		/// </summary>
		[DbColumn ("teacher_id", SqlDbType.NVarChar, true)]
		public int ClassTeacherId { get; set; }

		#endregion
	}
}