using System;

using ParameterizedQuery.Framework.Entities;

// ReSharper disable CheckNamespace
// ReSharper disable ClassCannotBeInstantiated

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private methods.

		/// <summary>
		/// Handles the ".IsNull ()" and ".IsNotNull ()" calls in the expression.
		/// </summary>
		/// <param name="expressionText">The expression text.</param>
		/// <returns></returns>
		private string HandleIsNullCondition (string expressionText)
		{
			// Yes.
			var entityAndPropertyPart
				= expressionText
					.Replace (" Is ", String.Empty)
					.Replace ("NotNull", String.Empty)
					.Replace ("Null", String.Empty);

			// Locate the period.
			var periodLocation = entityAndPropertyPart.IndexOf (".", StringComparison.Ordinal);

			// Is there one?
			if (periodLocation == -1)
			{
				// No.
				throw (new ParameterizedQueryException ("Cannot identify the property from the expression \"" + expressionText + "\"."));
			}

			// Ge the parts.
			var tableAlias = entityAndPropertyPart.Substring (0, periodLocation);
			var propertyName = entityAndPropertyPart.Substring (periodLocation + 1);

			// Get the DB column name for the property.
			var dbPropertyName = this.GetDbColumnNameOf (tableAlias, propertyName);

			var whereCondition
				= expressionText
					.Replace (" Is ", " is ")
					.Replace (" Null", " null")
					.Replace (" NotNull", " not null")
					.Replace (entityAndPropertyPart, tableAlias + "." + dbPropertyName);

			return (whereCondition);
		}

		#endregion
	}
}