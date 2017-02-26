using System;
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
		#region Private instance fields.

		/// <summary>
		/// The entity corresponding to the "from" clause.
		/// </summary>
		private Type fromEntityType;

		#endregion

		#region The "From" methods.

		/// <summary>
		/// Accepts the FROM clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic type of the entity that marks the starting of the FROM clause of a T-SQL statement.</typeparam>
		/// <returns></returns>
		public ParameterizedSqlQuery From<T1> ()
			where T1 : new()
		{
			this.fromEntityType = typeof (T1);
			return (this);
		}

		#endregion
	}
}