namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Contains fluent extension methods for the parameterized T-SQL query framework.
	/// </summary>
	public static class ParameterizedQueryExtensions
	{
		#region Static extension methods.

		/// <summary>
		/// Simulates the " like " comparison in T-SQL.
		/// </summary>
		/// <param name="entityProperty">The property of an entity on which the method is called.</param>
		/// <param name="comaparedText">The text to be compared with.</param>
		/// <returns></returns>
		public static bool Like (this string entityProperty, string comaparedText)
		{
			return (true);
		}

		/// <summary>
		/// Simulates the " not like " comparison in T-SQL.
		/// </summary>
		/// <param name="propertyName">The property of an entity on which the method is called.</param>
		/// <param name="comaparedText">The text to be compared with.</param>
		/// <returns></returns>
		public static bool NotLike (this string propertyName, string comaparedText)
		{
			return (true);
		}

		#endregion
	}
}