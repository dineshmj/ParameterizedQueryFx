using System;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents an exception thrown by the parameter query library.
	/// </summary>
	public sealed class ParameterizedQueryException
		: Exception
	{
		#region Constructors.

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="message">The exception message.</param>
		public ParameterizedQueryException (string message)
			: base (message)
		{
			// Intentionally left blank.
		}

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="message">The exception message.</param>
		/// <param name="innerException">The inner exception.</param>
		public ParameterizedQueryException (string message, Exception innerException)
			: base (message, innerException)
		{
			// Intentionally left blank.
		}

		#endregion
	}
}