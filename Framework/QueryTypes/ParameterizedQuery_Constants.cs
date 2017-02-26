using System.Diagnostics.CodeAnalysis;

// ReSharper disable CheckNamespace

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	[SuppressMessage ("ReSharper", "ClassCannotBeInstantiated")]
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private instance fields and constants.

		private const string ORACLE_DATE_FORMAT = "dd-MMM-yyyy";
		private const string DATE_TIME_STAMP_FORMAT = "yyyyMMdd_hhmmss";
		private const string SQL_PARAM_DATE_VALUE_PREFIX = "@param_dateValue_";
		private const string PARAM_PREFIX = "@param_";
		private const string ALWAYS_TRUE_CONDITION = "1 == 1";

		#endregion
	}
}