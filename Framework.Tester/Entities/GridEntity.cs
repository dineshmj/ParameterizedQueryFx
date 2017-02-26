using System.Data;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.Tester.Entities
{
	/// <summary>
	/// Represents a person.
	/// </summary>
	public sealed class GridEntity
	{
		#region Properties.

		/// <summary>
		/// The institution name.
		/// </summary>
		[DbColumn("InstitutionName", SqlDbType.NVarChar)]
		public string InstitutionName { get; set; }

		/// <summary>
		/// The age of the student.
		/// </summary>
		[DbColumn ("Age", SqlDbType.Int)]
		public int Age { get; set; }
		
		/// <summary>
		/// The unique ID of the student.
		/// </summary>
		[DbColumn ("StudentId", SqlDbType.Int, true)]
		public int StudentId { get; set; }

		/// <summary>
		/// The first name of the student.
		/// </summary>
		[DbColumn ("StudentFirstName", SqlDbType.NVarChar, true)]
		public string StudentFirstName { get; set; }

		/// <summary>
		/// The last name of the student.
		/// </summary>
		[DbColumn ("StudentLastName", SqlDbType.NVarChar, true)]
		public string StudentLastName { get; set; }
		
		/// <summary>
		/// The grade of the student.
		/// </summary>
		[DbColumn ("Grade", SqlDbType.Int)]
		public int Grade { get; set; }

		/// <summary>
		/// The special status.
		/// </summary>
		[DbColumn ("SpecialStatus", SqlDbType.NVarChar, true)]
		public string SpecialStatus { get; set; }

		/// <summary>
		/// The class division.
		/// </summary>
		[DbColumn ("Division", SqlDbType.NVarChar, true)]
		public string Division { get; set; }

		/// <summary>
		/// The first name of the Teacher.
		/// </summary>
		[DbColumn ("TeacherFirstName", SqlDbType.NVarChar, true)]
		public string TeacherFirstName { get; set; }

		/// <summary>
		/// The last name of the teacher.
		/// </summary>
		[DbColumn ("TeacherLastName", SqlDbType.NVarChar, true)]
		public string TeacherLastName { get; set; }

		/// <summary>
		/// The unique ID of the teacher.
		/// </summary>
		[DbColumn ("TeacherId", SqlDbType.Int, true)]
		public int TeacherId { get; set; }

		#endregion
	}
}