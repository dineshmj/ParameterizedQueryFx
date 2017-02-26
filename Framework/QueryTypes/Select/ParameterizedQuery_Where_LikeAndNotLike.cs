using System;
using System.Linq.Expressions;

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
		/// Handles the ".StartsWith ()" and ".EndsWith ()" calls within the WHERE condition
		/// boolean expressions.
		/// </summary>
		/// <param name="expression">The boolean expression.</param>
		/// <returns></returns>
		private string HandleStartsWithEndsWithLikeOrNotLikeCalls (Expression expression)
		{
			// Try casting as a method call.
			var methodCall = expression as MethodCallExpression;              // Example:  { c.Grade.In (10, 11, 12) }
			var likeOrNotLikeCall = false;

			// Is it a method?
			if (methodCall != null)
			{
				string callingProperty;

				// Yes. Is it a "System.String" method call (.StartsWith (), or .EndsWith ())?
				if (methodCall.Object != null)
				{
					// Yes.
					callingProperty = methodCall.Object.ToString ();
				}
				else
				{
					// No, the call is either for ".Like ()", or ".NotLike ()".
					likeOrNotLikeCall = true;

					// Locate the "like" or "not like" location.
					var expressionString = methodCall.ToString ();
					var dotLikeLocation = expressionString.IndexOf (".Like(", StringComparison.Ordinal);
					var dotNotLikeLocation = expressionString.IndexOf (".NotLike(", StringComparison.Ordinal);

					// Is it a ".Like ()" call?
					if (dotLikeLocation != -1)
					{
						callingProperty = expressionString.Substring (0, dotLikeLocation);
					}
					// Is it a ".NotLike ()" call?
					else if (dotNotLikeLocation != -1)
					{
						callingProperty = expressionString.Substring (0, dotNotLikeLocation);
					}
					else
					{
						// The method call could not be identified.
						throw (new ParameterizedQueryException ("The LHS of a \".Like ()\" or \".NotLike ()\" comparison must be an entity property."));
					}
				}

				// Split the property reference based on "."
				var periodLocation = callingProperty.IndexOf (".", StringComparison.Ordinal);
				var tableAlias = callingProperty.Substring (0, periodLocation);
				var propertyName = callingProperty.Substring (periodLocation + 1);
				var propertyDbName = this.GetDbColumnNameOf (tableAlias, propertyName);

				// Get the type of call - ".StartsWith ()", or ".EndsWith ()"
				var calledMethod
					= methodCall
						.Method
						.ToString ()
						.Replace ("Boolean ", String.Empty)
						.Replace ("(System.String, System.String)", String.Empty)
						.Replace ("(System.String)", String.Empty);

				// Get the value compared with.

				var comparedToExpression
					= likeOrNotLikeCall == false
						? methodCall.Arguments [0]
						: methodCall.Arguments [1];

				// Get the value compared with.
				var comparedText = comparedToExpression.ToString ();

				// Is it a string text, surrounded by double quotes?
				if (comparedText.IndexOf ("\"", StringComparison.Ordinal) == -1)
				{
					// No. It appears it is a variable. Get the variable value.
					var memberExpression = comparedToExpression as MemberExpression;
					string localVariableName;
					object localVariableValue;
					Type localVariableType;

					// Extract the local variable info.
					this.ExtractLocalVariableFromExpression (memberExpression, out localVariableName, out localVariableValue, out localVariableType);
					comparedText = (string) localVariableValue;
				}

				// Add the " like " operator, only if the compared text isn't null.
				if (String.IsNullOrEmpty (comparedText))
				{
					return (ALWAYS_TRUE_CONDITION);
				}
				else
				{
					switch (calledMethod)
					{
						case "StartsWith":
							return (tableAlias + "." + propertyDbName + " like '" + comparedText.Replace ("'", "''") + "%'");

						case "EndsWith":
							return (tableAlias + "." + propertyDbName + " like '%" + comparedText.Replace ("'", "''") + "'");

						case "Like":
							comparedText = comparedText.Replace ("*", "%").Replace ("?", "_");
							return (tableAlias + "." + propertyDbName + " like '%" + comparedText.Replace ("'", "''") + "%'");

						case "NotLike":
							comparedText = comparedText.Replace ("*", "%").Replace ("?", "_");
							return (tableAlias + "." + propertyDbName + " not like '%" + comparedText.Replace ("'", "''") + "%'");
					}
				}
			}

			return (String.Empty);
		}

		#endregion
	}
}