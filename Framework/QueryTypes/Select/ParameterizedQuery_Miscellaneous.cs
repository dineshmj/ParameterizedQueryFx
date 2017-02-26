using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

using ParameterizedQuery.Framework.Entities;

// ReSharper disable CheckNamespace

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	[SuppressMessage ("ReSharper", "ClassCannotBeInstantiated")]
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private miscellaneous methods.

		/// <summary>
		/// Adds the necessary tabs to form the indent.
		/// </summary>
		/// <param name="builder">The string builder.</param>
		/// <param name="indent">The number of indents.</param>
		private void AddIndent (StringBuilder builder, int indent)
		{
			for (var i = 0; i < indent; i++)
			{
				builder.Append ("\t");
			}
		}

		/// <summary>
		/// Adds the query parameter to the list.
		/// </summary>
		/// <param name="parameter">The T-SQL query parameter to be added.</param>
		private void AddToSqlQueryParameters (SqlQueryParameter parameter)
		{
			// Is it already added?
			if (this.sqlParameters.FirstOrDefault (p => p.Name == parameter.Name) == null)
			{
				// Not yet.
				this.sqlParameters.Add (parameter);
			}
		}

		#endregion
	}
}