using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using ParameterizedQuery.Framework.Entities;
using ParameterizedQuery.Framework.Extensions;

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
		/// Handles the ".In ()" and ".NotIn ()" calls within the WHERE condition
		/// boolean expressions.
		/// </summary>
		/// <param name="expression">The boolean expression.</param>
		/// <returns></returns>
		private string HandleInCall (Expression expression)
		{
			Type memberPropertyType;
			PropertyInfo memberPropertyInfo;
			string [] elements;
			string memberPropertyText;

			// Extract the following:
			//    (1) The text of the property that calls the ".In ()" method.
			//    (2) The type of the property that calls the ".In ()" method.
			//    (3) The array of values in the ".In ()" part.
			this.ExtractInArrayContents
				(
					expression,
					out memberPropertyInfo,
					out memberPropertyType,
					out memberPropertyText,
					out elements
				);

			var inOrNotInText
				= (expression.ToString ().IndexOf (".In(", StringComparison.Ordinal) != -1)
					? " in ("
					: " not in (";

			// Are the elements numbers?
			if (memberPropertyType.IsNumber ())
			{
				return (memberPropertyText + inOrNotInText + String.Join (", ", elements) + ")");
			}

			// Are the elements text?
			if (memberPropertyType.IsText ())
			{
				var elementsReplacedBySqlParameters = new List<string> ();

				elements
					.ToList ()
					.ForEach
						(
							e =>
							{
								var sqlParameter = new SqlQueryParameter (e.Replace ("\"", String.Empty), SqlDbType.NVarChar);
								this.AddToSqlQueryParameters (sqlParameter);

								elementsReplacedBySqlParameters.Add (sqlParameter.Name);
							}
						);

				return
					(
						memberPropertyText
							+ inOrNotInText
							+ String.Join (", ", elementsReplacedBySqlParameters.Select (s => s).ToList ())
							+ ")"
					);
			}

			// Are the elements dates?
			if (memberPropertyType == typeof (DateTime))
			{
				return (memberPropertyText + inOrNotInText + String.Join (", ", elements.Select (s => "convert (datetime, '" + s.Replace ("\"", String.Empty) + "', 106)").ToList ()) + ")");
			}

			// The type is not ready yet to be processed.
			throw (new NotImplementedException ("Handling of \".In ()\" call with type \"" + memberPropertyType.Name + "\" is not yet implemented."));
		}

		/// <summary>
		/// Extracts the entity's property's type in the " in " (or " not in ") call expression.
		/// </summary>
		/// <param name="inCallExpression">The " in " call expression.</param>
		/// <param name="memberPropertyInfo">The property info of the entity property.</param>
		/// <param name="memberPropertyType">The type of the property in question.</param>
		/// <param name="memberPropertyText">The text of the localVarExpression property.</param>
		/// <param name="elements">The elements of the array.</param>
		private void ExtractInArrayContents
			(
				Expression inCallExpression,
				out PropertyInfo memberPropertyInfo,
				out Type memberPropertyType,
				out string memberPropertyText,
				out string [] elements
			)
		{
			// Extract the type of the property from the expression.
			this.IsPropertyPartExtractbleFromExpression
				(
					inCallExpression,
					out memberPropertyInfo,
					out memberPropertyText,
					out memberPropertyType
				);

			// Get the ".In ()" method call.
			var methodCall = inCallExpression as MethodCallExpression;              // Example:  { c.Grade.In (10, 11, 12) }

			// Is there a method call?
			if (methodCall == null)
			{
				// No.
				memberPropertyInfo = null;
				memberPropertyType = null;
				memberPropertyText = String.Empty;
				elements = null;

				return;
			}

			// Get the "new {}" expression.
			var newArrayExpression = methodCall.Arguments [1] as NewArrayExpression;

			// Is it a hard-coded list?
			if (newArrayExpression == null)
			{
				// No, apparently, the argument of ".In ()" method is a local variable that is an array or an IList.
				var dates = this.ExractDatesArrayFrom (methodCall.Arguments [1]);

				elements = dates.Select (d => d.ToString ("dd-MMM-yyyy")).ToArray ();
			}
			// Is the compared property a date-time?
			else if (memberPropertyType == typeof (DateTime))
			{
				elements
					= newArrayExpression
						.Expressions
						.Select
						(
							e =>
							{
								var newExpression = e as NewExpression;
								// ReSharper disable once PossibleNullReferenceException
								var yearMonthAndDateParts = newExpression.Arguments.Select (v => Int32.Parse (v.ToString ())).ToList ();
								var dateValue = new DateTime (yearMonthAndDateParts [0], yearMonthAndDateParts [1], yearMonthAndDateParts [2]);
								return (dateValue.ToString (ORACLE_DATE_FORMAT));
							}
						)
						.ToArray ();
			}
			else
			// Extract the elements.
			{
				elements = newArrayExpression.Expressions.Select (e => e.ToString ()).ToArray ();
			}
		}

		#endregion
	}
}