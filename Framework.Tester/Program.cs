using System;
using System.Windows.Forms;

namespace ParameterizedQuery.Framework.Tester
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main ()
		{
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault (false);

			// http://stackoverflow.com/questions/11905185/executing-query-with-parameters
			DisplaySqlScreen.DefinedInstance.ShowDialog ();
		}
	}
}
