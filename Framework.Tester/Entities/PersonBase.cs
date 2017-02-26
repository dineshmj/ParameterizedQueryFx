using System;
using System.Data;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.Tester.Entities
{
	/// <summary>
	/// Represents a person.
	/// </summary>
	public abstract class PersonBase
	{
		#region Properties.

		/// <summary>
		/// The salutation of the person.
		/// </summary>
		[DbColumn ("salute_text", SqlDbType.NVarChar, false)]
		public string Salutation { get; set; }

		/// <summary>
		/// The first name of the person.
		/// </summary>
		[DbColumn ("first_name", SqlDbType.NVarChar, false)]
		public string FirstName { get; set; }

		/// <summary>
		/// The last name of the person.
		/// </summary>
		[DbColumn ("last_name", SqlDbType.NVarChar, false)]
		public string LastName { get; set; }

		/// <summary>
		/// The full name of the person.
		/// </summary>
		public string FullName { get { return (String.Concat (this.FirstName, " ", this.LastName)); } }

		/// <summary>
		/// The date of birth of the person.
		/// </summary>
		[DbColumn ("birth_date", SqlDbType.DateTime, false)]
		public DateTime DateOfBirth { get; set; }

		#endregion
	}
}