using System;
using System.Linq;

namespace ParameterizedQuery.Framework.Extensions
{
	/// <summary>
	/// Contains extensions to lists to simulate " in ( ... ) " and " not in ( ... ) " constructs
	/// in the T-SQL query.
	/// </summary>
	public static class ParameterizedQueryExtensions
	{
		#region Static extension methods.

		/// <summary>
		/// A static extension method to be able to call ".In () " from any property of an entity.
		/// </summary>
		/// <typeparam name="TTarget">The generic type of the target property that calls this method.</typeparam>
		/// <param name="callingObject">The instance of the target property that calls the method.</param>
		/// <param name="paramValues">A list of param values in the ".In ()" comparison.</param>
		/// <returns></returns>
		public static bool In<TTarget> (this TTarget callingObject, params TTarget [] paramValues)
		{
			// Are there any param values?
			if (paramValues == null || paramValues.Length == 0)
			{
				// No. Nothing to compare with. Comparison fails.
				return (false);
			}

			// Perofrm comparison.
			return (paramValues.Contains (callingObject));
		}

		/// <summary>
		/// A static extension method to be able to call ".NotIn ()" from any property of an entity.
		/// </summary>
		/// <typeparam name="TTarget">The generic type of the target property that calls this method.</typeparam>
		/// <param name="callingObject">The instance of the target property that calls the method.</param>
		/// <param name="paramValues">A list of param values in the ".NotIn ()" comparison.</param>
		/// <returns></returns>
		public static bool NotIn<TTarget> (this TTarget callingObject, params TTarget [] paramValues)
		{
			// The opposite of what ".In ()" does.
			return (!callingObject.In (paramValues));
		}

		/// <summary>
		/// Checks if the specified type is a number type.
		/// </summary>
		/// <param name="numberType">The type to be checked.</param>
		/// <returns></returns>
		public static bool IsNumber (this Type numberType)
		{
			return (numberType.In (typeof (short), typeof (int), typeof (long)));
		}

		/// <summary>
		/// Checks if the specified type is a text type (char, or string).
		/// </summary>
		/// <param name="textType">The type to be checked.</param>
		/// <returns></returns>
		public static bool IsText (this Type textType)
		{
			return (textType.In (typeof (char), typeof (string)));
		}

		#endregion
	}
}