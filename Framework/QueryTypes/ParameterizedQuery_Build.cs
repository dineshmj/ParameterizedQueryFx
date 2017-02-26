using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

using ParameterizedQuery.Framework.Entities;

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	[SuppressMessage ("ReSharper", "ClassCannotBeInstantiated")]
	public sealed partial class ParameterizedSqlQuery
	{
		#region Methods.

		/// <summary>
		/// Builds the T-SQL query statement.
		/// </summary>
		/// <returns></returns>
		public SqlCommand BuildSqlCommand (out string runnableSqlScript, out string parameterizedQueryAlone)
		{
			switch (this.queryType)
			{
				case SqlQueryType.NotSetYet:
					break;

				case SqlQueryType.Select:
					var sqlCommand = this.BuildParameterizedSelectCommand ();
					parameterizedQueryAlone = sqlCommand.CommandText;
					runnableSqlScript = this.AddSqlParametersDefinition () + parameterizedQueryAlone;
					return (sqlCommand);

				case SqlQueryType.Insert:
					throw (new NotImplementedException ());

				case SqlQueryType.Update:
					throw (new NotImplementedException ());

				case SqlQueryType.Delete:
					throw (new NotImplementedException ());
			}

			throw (new ParameterizedQueryException ("The type of the SQL query could not be identified."));
		}

		#endregion
	}
}