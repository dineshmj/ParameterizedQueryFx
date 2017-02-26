using System;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents a T-SQL value of "null". This class does not carry any properties,
	/// and the sole purpose is the fluency of the parameterized query building process.
	/// </summary>
	public sealed class Null
	{
		#region Static properties.

		/// <summary>
		/// Represents a "null" column in the SELECT clause of a SQL query.
		/// </summary>
		public static string AsColumn
		{
			get { return (String.Empty); }
		}

		#endregion
	}
}