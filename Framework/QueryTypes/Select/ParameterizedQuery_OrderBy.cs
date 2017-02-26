using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ParameterizedQuery.Framework.Entities;

// ReSharper disable ClassCannotBeInstantiated
// ReSharper disable CheckNamespace

namespace ParameterizedQuery.Framework.QueryTypes
{
	/// <summary>
	/// Represents a parameterized T-SQL query.
	/// </summary>
	public sealed partial class ParameterizedSqlQuery
	{
		#region Private readonly instance fields.

		/// <summary>
		/// A list of entity names, and their properties that would represent the
		/// SELECT clause of a T-SQL statement.
		/// </summary>
		private readonly IList<ColumnInfo> orderByColumns;

		#endregion

		#region The "Select" methods.
		
		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1>
			(
				Func<T1, object> f1
			)
			where T1 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause.
			this.IdentifyOrderByClauseColumns (f1);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2>
			(
				Func<T1, object> f1,
				Func<T2, object> f2
			)
			where T1 : new()
			where T2 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f9">A func that returns an anonymous type with properties from the ninth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8, T9>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8,
				Func<T9, object> f9
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);
			this.IdentifyOrderByClauseColumns (f9);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f9">A func that returns an anonymous type with properties from the ninth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f10">A func that returns an anonymous type with properties from the tenth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8,
				Func<T9, object> f9,
				Func<T10, object> f10
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);
			this.IdentifyOrderByClauseColumns (f9);
			this.IdentifyOrderByClauseColumns (f10);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f9">A func that returns an anonymous type with properties from the ninth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f10">A func that returns an anonymous type with properties from the tenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f11">A func that returns an anonymous type with properties from the eleventh generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8,
				Func<T9, object> f9,
				Func<T10, object> f10,
				Func<T11, object> f11
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);
			this.IdentifyOrderByClauseColumns (f9);
			this.IdentifyOrderByClauseColumns (f10);
			this.IdentifyOrderByClauseColumns (f11);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f9">A func that returns an anonymous type with properties from the ninth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f10">A func that returns an anonymous type with properties from the tenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f11">A func that returns an anonymous type with properties from the eleventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f12">A func that returns an anonymous type with properties from the twelfth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8,
				Func<T9, object> f9,
				Func<T10, object> f10,
				Func<T11, object> f11,
				Func<T12, object> f12
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);
			this.IdentifyOrderByClauseColumns (f9);
			this.IdentifyOrderByClauseColumns (f10);
			this.IdentifyOrderByClauseColumns (f11);
			this.IdentifyOrderByClauseColumns (f12);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <typeparam name="T13">The generic entity type representing the thirteenth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f9">A func that returns an anonymous type with properties from the ninth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f10">A func that returns an anonymous type with properties from the tenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f11">A func that returns an anonymous type with properties from the eleventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f12">A func that returns an anonymous type with properties from the twelfth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f13">A func that returns an anonymous type with properties from the thirteenth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8,
				Func<T9, object> f9,
				Func<T10, object> f10,
				Func<T11, object> f11,
				Func<T12, object> f12,
				Func<T13, object> f13
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
			where T13 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);
			this.IdentifyOrderByClauseColumns (f9);
			this.IdentifyOrderByClauseColumns (f10);
			this.IdentifyOrderByClauseColumns (f11);
			this.IdentifyOrderByClauseColumns (f12);
			this.IdentifyOrderByClauseColumns (f13);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <typeparam name="T13">The generic entity type representing the thirteenth DB table.</typeparam>
		/// <typeparam name="T14">The generic entity type representing the fourteenth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f9">A func that returns an anonymous type with properties from the ninth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f10">A func that returns an anonymous type with properties from the tenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f11">A func that returns an anonymous type with properties from the eleventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f12">A func that returns an anonymous type with properties from the twelfth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f13">A func that returns an anonymous type with properties from the thirteenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f14">A func that returns an anonymous type with properties from the fourteenth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8,
				Func<T9, object> f9,
				Func<T10, object> f10,
				Func<T11, object> f11,
				Func<T12, object> f12,
				Func<T13, object> f13,
				Func<T14, object> f14
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
			where T13 : new()
			where T14 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);
			this.IdentifyOrderByClauseColumns (f9);
			this.IdentifyOrderByClauseColumns (f10);
			this.IdentifyOrderByClauseColumns (f11);
			this.IdentifyOrderByClauseColumns (f12);
			this.IdentifyOrderByClauseColumns (f13);
			this.IdentifyOrderByClauseColumns (f14);

			return (this);
		}

		/// <summary>
		/// Accepts the ORDER BY clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <typeparam name="T4">The generic entity type representing the fourth DB table.</typeparam>
		/// <typeparam name="T5">The generic entity type representing the fifth DB table.</typeparam>
		/// <typeparam name="T6">The generic entity type representing the sixth DB table.</typeparam>
		/// <typeparam name="T7">The generic entity type representing the seventh DB table.</typeparam>
		/// <typeparam name="T8">The generic entity type representing the eighth DB table.</typeparam>
		/// <typeparam name="T9">The generic entity type representing the ninth DB table.</typeparam>
		/// <typeparam name="T10">The generic entity type representing the tenth DB table.</typeparam>
		/// <typeparam name="T11">The generic entity type representing the eleventh DB table.</typeparam>
		/// <typeparam name="T12">The generic entity type representing the twelfth DB table.</typeparam>
		/// <typeparam name="T13">The generic entity type representing the thirteenth DB table.</typeparam>
		/// <typeparam name="T14">The generic entity type representing the fourteenth DB table.</typeparam>
		/// <typeparam name="T15">The generic entity type representing the fifteenth DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f4">A func that returns an anonymous type with properties from the fourth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f5">A func that returns an anonymous type with properties from the fifth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f6">A func that returns an anonymous type with properties from the sixth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f7">A func that returns an anonymous type with properties from the seventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f8">A func that returns an anonymous type with properties from the eighth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f9">A func that returns an anonymous type with properties from the ninth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f10">A func that returns an anonymous type with properties from the tenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f11">A func that returns an anonymous type with properties from the eleventh generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f12">A func that returns an anonymous type with properties from the twelfth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f13">A func that returns an anonymous type with properties from the thirteenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f14">A func that returns an anonymous type with properties from the fourteenth generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f15">A func that returns an anonymous type with properties from the fifteenth generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery OrderBy<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
			(
				Func<T1, object> f1,
				Func<T2, object> f2,
				Func<T3, object> f3,
				Func<T4, object> f4,
				Func<T5, object> f5,
				Func<T6, object> f6,
				Func<T7, object> f7,
				Func<T8, object> f8,
				Func<T9, object> f9,
				Func<T10, object> f10,
				Func<T11, object> f11,
				Func<T12, object> f12,
				Func<T13, object> f13,
				Func<T14, object> f14,
				Func<T15, object> f15
			)
			where T1 : new()
			where T2 : new()
			where T3 : new()
			where T4 : new()
			where T5 : new()
			where T6 : new()
			where T7 : new()
			where T8 : new()
			where T9 : new()
			where T10 : new()
			where T11 : new()
			where T12 : new()
			where T13 : new()
			where T14 : new()
			where T15 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.IdentifyOrderByClauseColumns (f1);
			this.IdentifyOrderByClauseColumns (f2);
			this.IdentifyOrderByClauseColumns (f3);
			this.IdentifyOrderByClauseColumns (f4);
			this.IdentifyOrderByClauseColumns (f5);
			this.IdentifyOrderByClauseColumns (f6);
			this.IdentifyOrderByClauseColumns (f7);
			this.IdentifyOrderByClauseColumns (f8);
			this.IdentifyOrderByClauseColumns (f9);
			this.IdentifyOrderByClauseColumns (f10);
			this.IdentifyOrderByClauseColumns (f11);
			this.IdentifyOrderByClauseColumns (f12);
			this.IdentifyOrderByClauseColumns (f13);
			this.IdentifyOrderByClauseColumns (f14);
			this.IdentifyOrderByClauseColumns (f15);

			return (this);
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Extracts the properties, and forms a list of entities and their properties to represent
		/// the SELECT clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="TEntity">The generic type representing the target DB table.</typeparam>
		/// <param name="func">A func that returns an anonymous type with properties from the generic entity type, to represent the SELECT clause columns.</param>
		private void IdentifyOrderByClauseColumns<TEntity> (Func<TEntity, object> func)
			where TEntity : new()
		{
			// Get the entity type, and form a dummy instance.
			var entityType = typeof (TEntity);
			var dummyInstance = new TEntity ();

			// Is the func valid?
			if (func != null)
			{
				// Yes.
				func
					.Invoke (dummyInstance)     // Get the anonymous type instnace.
					.GetType ()                 // Get the anonymous type.
					.GetProperties ()           // Get the properties of the anonymous type.
					.ToList ()                  // Form a list.
					.ForEach
						(
							p =>
							{
								// Get the corresponding property from the entity.
								var columnProperty
									= entityType.GetProperties ()
										.FirstOrDefault (pr => pr.Name == p.Name);

								// Was a valid property detected on the table entity?
								if (columnProperty == null)
								{
									// No. This is because a local variable was used instead of a "t.Column" styled call.
									throw (new ParameterizedQueryException ("Only column names identified by the entity properties are allowed in the \"order by \" clause."));
								}

								// Prepare the order by column.
								var orederByColumn
									= new ColumnInfo
										{
											TableEntity = entityType,
											ColumnProperty = columnProperty
										};

								// Is it part of the "select" clause columns list?
								var presentAmongSelectClauseColumns
									= this.columnsToSelect
										.Any
											(
												c =>
													c != null
													&& c.TableEntity == orederByColumn.TableEntity
													&& c.ColumnProperty == orederByColumn.ColumnProperty
											);

								// Is this column there in the "select" clause?
								if (presentAmongSelectClauseColumns == false)
								{
									// No.
									throw (new ParameterizedQueryException ("Only column names present in the \"select\" clause are allowed in the \"order by\" clause."));
								}

								// Not a local variable, but an entity.Property statement.
								// Add the table and column names to the list.
								this.orderByColumns.Add
									(
										orederByColumn
									);
							}
						);
			}
		}

		/// <summary>
		/// Adds the order by clause to the T-SQL query statement.
		/// </summary>
		/// <param name="builder">The string builder.</param>
		private void AddOrderByClause (StringBuilder builder)
		{
			// Are there any order by columns?
			if (this.orderByColumns.Count == 0)
			{
				// No.
				return;
			}

			builder.Append ("order by");
			builder.AppendLine ();

			var loopCounter = 0;

			// Add each order by column.
			foreach (var oneColumn in this.orderByColumns)
			{
				builder.Append ("\t");
				builder.Append (this.GetAliasForTable (oneColumn.TableEntity));
				builder.Append (".");
				builder.Append (this.GetDbColumnNameOf (oneColumn.ColumnProperty));

				// Add a comma at the end, only if this is not the last column.
				if (loopCounter < this.orderByColumns.Count - 1)
				{
					builder.Append (",");
				}

				builder.AppendLine ();
				loopCounter++;
			}
		}

		#endregion
	}
}