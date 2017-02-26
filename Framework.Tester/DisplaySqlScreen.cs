using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using ParameterizedQuery.Framework.Entities;
using ParameterizedQuery.Framework.QueryTypes;
using ParameterizedQuery.Framework.Tester.Entities;
using ParameterizedQuery.Framework.Extensions;

namespace ParameterizedQuery.Framework.Tester
{
	/// <summary>
	/// The UI screen that shows the generated T-SQL runnable script.
	/// </summary>
	public partial class DisplaySqlScreen : Form
	{
		#region Private instance and static fields.

		/// <summary>
		/// For singleton implementation - the synchronized locker.
		/// </summary>
		private static readonly object syncLocker = new object ();

		/// <summary>
		/// The defined instance of this UI screen.
		/// </summary>
		private static DisplaySqlScreen definedInstance;

		private const int EM_SETTABSTOPS = 0x00CB;

		#endregion

		#region Imported methods.

		/// <summary>
		/// Helps set the width of the TAB character in a text area.
		/// </summary>
		[DllImport ("User32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage (IntPtr h, int msg, int wParam, int [] lParam);

		#endregion

		#region Properties.

		/// <summary>
		/// The singleton instance of this UI screen.
		/// </summary>
		public static DisplaySqlScreen DefinedInstance
		{
			get
			{
				lock (syncLocker)
				{
					// Is it already instantiated?
					if (definedInstance == null)
					{
						// No.
						definedInstance = new DisplaySqlScreen ();
					}

					return (definedInstance);
				}
			}
		}

		#endregion

		#region Constructors.

		/// <summary>
		/// Instantiates this screen.
		/// </summary>
		private DisplaySqlScreen ()
		{
			this.InitializeComponent ();

			// Set the TAB width to 4 characters.
			SendMessage (this.sqlTextArea.Handle, EM_SETTABSTOPS, 1, new [] { 8 });
		}

		#endregion

		#region Methods.

		/// <summary>
		/// Sets the specified text to the text area.
		/// </summary>
		/// <param name="text">The text to be displayed.</param>
		public void SetTextToArea (string text)
		{
			this.sqlTextArea.Text = text;
			this.sqlTextArea.SelectionStart = 0;
			this.sqlTextArea.SelectionLength = 0;
		}

		#endregion

		#region Event handlers.

		/// <summary>
		/// Handles the quit button click event.
		/// </summary>
		/// <param name="sender">This UI screen instance.</param>
		/// <param name="e">The event arguments.</param>
		private void quitButton_Click (object sender, EventArgs e)
		{
			this.Close ();
		}

		/// <summary>
		/// Handles the re-build SQL button click event.
		/// </summary>
		/// <param name="sender">This UI screen instance.</param>
		/// <param name="e">The event arguments.</param>
		private void rebuildSqlButton_Click (object sender, EventArgs e)
		{
			this.BuildScript ();
		}

		/// <summary>
		/// Loads this screen.
		/// </summary>
		/// <param name="sender">This UI screen instance.</param>
		/// <param name="e">The event arguments.</param>
		private void DisplaySqlScreen_Load (object sender, EventArgs e)
		{
			this.BuildScript ();
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Builds the T-SQL script.
		/// </summary>
		private void BuildScript ()
		{
			// The runnable script.
			string runnableSqlScript, parameterizedQueryAlone;
			var sqlCommand = this.GenerateSqlOne (out runnableSqlScript, out parameterizedQueryAlone);
			this.SetTextToArea (runnableSqlScript);
		}

		/// <summary>
		/// Generates the first T-SQL script.
		/// </summary>
		/// <param name="runnableSqlScript">The runnable T-SQL script that the framework generates.</param>
		/// <param name="parameterizedQueryAlone">The part of the above script with only the parameterized query.</param>
		/// <returns></returns>
		private SqlCommand GenerateSqlOne (out string runnableSqlScript, out string parameterizedQueryAlone)
		{
			// Local variables referenced in the query.
			var institutionName = "Oxford University";

			var studentFirstName = "Steve";
			var studentLastName = "Jobs";
			string notLikeCompareText = null;

			var birthDateFloorValue = new DateTime (1970, 1, 1);
			var age = 22;
			var tempDates
				= new []
					{
						new DateTime (1900, 1, 1),
						new DateTime (1995, 1, 1),
						new DateTime (2000, 1, 1)
					};

			// The actual query using entities.
			var sqlCommand
				= ParameterizedSqlQuery
					.New ()
					.TableAliasesAs<Student, ClassRoom, ClassTeacherInfo, Teacher> ("s", "c", "ct", "t")
					.Distinct ()
					.Select<Student, ClassRoom, Teacher>
						(
							s => new { institutionName, age, s.Id, s.FirstName, s.LastName },
							c => new { c.Grade, Null.AsColumn, c.Division },
							t => new { t.FirstName, t.LastName, t.Id }
						)
					.ColumnAliasesAs
						(
							"InstitutionName",
							"Age",
							"StudentId",
							"StudentFirstName",
							"StudentLastName",
							"Grade",
							"SpecialStatus",
							"Division",
							"TeacherFirstName",
							"TeacherLastName",
							"TeacherId"
						)
					.From<Student> ()
						.InnerJoinWith<Student, ClassRoom, int> (s => s.ClassRoomId)
						.InnerJoinWith<ClassRoom, ClassTeacherInfo> ((c, ct) => c.Id == ct.ClassRoomId)
						.InnerJoinWith<ClassTeacherInfo, Teacher, int> (ct => ct.ClassTeacherId)
					.Where<Student, ClassRoom, ClassTeacherInfo, Teacher>
						(
							(s, c, ct, t) =>
								// s.FirstName.StartsWith ("Dinesh")
								s.FirstName.EndsWith (studentFirstName)
								&& s.LastName.Like (studentLastName)
								&& s.LastName.NotLike (notLikeCompareText)
								&& s.FirstName.In ("Steve", "Larry")
								&& t.Salutation is NotNull
								&&
								(
									(
										(
											c.Division == "A"
											|| c.Division == "B"
										)
										&&
										c.Grade.In (10, 11, 12)
									)
									||
									(
										c.Grade == 1
										|| c.Grade == 2
										|| c.Grade == 3
									)
								)
								&& c.Grade is NotNull
								&&
								(
									"A" == c.Division
									|| "B" == c.Division
								)
								&& c.Division.NotIn ("D", "E", "F")
								&& s.FirstName == studentFirstName
								&& s.Id > 0
								&& s.DateOfBirth > birthDateFloorValue
								&&
								(
									s.FirstName == "Steve"
									|| s.FirstName == "Jobs"
								)
								&& s.DateOfBirth < new DateTime (2000, 1, 1)
								&& s.DateOfBirth.NotIn (tempDates)
						)
					.OrderBy<Student, ClassRoom>
						(
							s => new { s.FirstName, s.LastName },
							c => new { c.Grade, c.Division }
						)
					.BuildSqlCommand (out runnableSqlScript, out parameterizedQueryAlone);

			return (sqlCommand);
		}

		#endregion
	}
}
