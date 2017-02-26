using System;
using System.Collections.Generic;
using System.Linq;

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
		private readonly IList<ColumnInfo> columnsToSelect;

		/// <summary>
		/// Indicates if the SELECT clause columns are to be distinct.
		/// </summary>
		private bool selectClauseDistinct;

		#endregion

		#region The "Select" methods.

		/// <summary>
		/// Specifies that the SELECT clause columns are distinct.
		/// </summary>
		/// <returns></returns>
		public ParameterizedSqlQuery Distinct ()
		{
			this.selectClauseDistinct = true;
			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Select<T1>
			(
				Func<T1, object> f1
			)
			where T1 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause.
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Select<T1, T2>
			(
				Func<T1, object> f1,
				Func<T2, object> f2
			)
			where T1 : new()
			where T2 : new()
		{
			// Extract the properties, and add to the list of columns of the SELECT clause from each entity func.
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="T1">The generic entity type representing the first DB table.</typeparam>
		/// <typeparam name="T2">The generic entity type representing the second DB table.</typeparam>
		/// <typeparam name="T3">The generic entity type representing the third DB table.</typeparam>
		/// <param name="f1">A func that returns an anonymous type with properties from the first generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f2">A func that returns an anonymous type with properties from the second generic entity type, to represent the SELECT clause columns.</param>
		/// <param name="f3">A func that returns an anonymous type with properties from the third generic entity type, to represent the SELECT clause columns.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery Select<T1, T2, T3>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8, T9>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);
			this.IdentifySelectClauseColumns (f9);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);
			this.IdentifySelectClauseColumns (f9);
			this.IdentifySelectClauseColumns (f10);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);
			this.IdentifySelectClauseColumns (f9);
			this.IdentifySelectClauseColumns (f10);
			this.IdentifySelectClauseColumns (f11);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);
			this.IdentifySelectClauseColumns (f9);
			this.IdentifySelectClauseColumns (f10);
			this.IdentifySelectClauseColumns (f11);
			this.IdentifySelectClauseColumns (f12);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);
			this.IdentifySelectClauseColumns (f9);
			this.IdentifySelectClauseColumns (f10);
			this.IdentifySelectClauseColumns (f11);
			this.IdentifySelectClauseColumns (f12);
			this.IdentifySelectClauseColumns (f13);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);
			this.IdentifySelectClauseColumns (f9);
			this.IdentifySelectClauseColumns (f10);
			this.IdentifySelectClauseColumns (f11);
			this.IdentifySelectClauseColumns (f12);
			this.IdentifySelectClauseColumns (f13);
			this.IdentifySelectClauseColumns (f14);

			return (this);
		}

		/// <summary>
		/// Accepts the SELECT clause of a T-SQL statement.
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
		public ParameterizedSqlQuery Select<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
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
			this.SetQueryTypeToSelect ();
			this.IdentifySelectClauseColumns (f1);
			this.IdentifySelectClauseColumns (f2);
			this.IdentifySelectClauseColumns (f3);
			this.IdentifySelectClauseColumns (f4);
			this.IdentifySelectClauseColumns (f5);
			this.IdentifySelectClauseColumns (f6);
			this.IdentifySelectClauseColumns (f7);
			this.IdentifySelectClauseColumns (f8);
			this.IdentifySelectClauseColumns (f9);
			this.IdentifySelectClauseColumns (f10);
			this.IdentifySelectClauseColumns (f11);
			this.IdentifySelectClauseColumns (f12);
			this.IdentifySelectClauseColumns (f13);
			this.IdentifySelectClauseColumns (f14);
			this.IdentifySelectClauseColumns (f15);

			return (this);
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Sets the query type to SELECT type.
		/// </summary>
		private void SetQueryTypeToSelect ()
		{
			// Has any other query type already started?
			if (this.queryType != SqlQueryType.NotSetYet)
			{
				// Yes.
				throw (new ParameterizedQueryException ("Cannot accept a SELECT clause once another query type has already started."));
			}

			// Set the query type.
			this.queryType = SqlQueryType.Select;
		}

		/// <summary>
		/// Extracts the properties, and forms a list of entities and their properties to represent
		/// the SELECT clause of a T-SQL statement.
		/// </summary>
		/// <typeparam name="TEntity">The generic type representing the target DB table.</typeparam>
		/// <param name="func">A func that returns an anonymous type with properties from the generic entity type, to represent the SELECT clause columns.</param>
		private void IdentifySelectClauseColumns<TEntity> (Func<TEntity, object> func)
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
							// Is the Anonymous class's property name "AsColumn", because the user used "Null.AsColumn" as the property?
							if (p.Name == "AsColumn")
							{
								// Yes. The user means a NULL column value field here.
								this.columnsToSelect.Add ((ColumnInfo) null);
								return;
							}

							// Get the corresponding property from the entity.
							var columnProperty
								= entityType.GetProperties ()
											.FirstOrDefault (pr => pr.Name == p.Name);

							// Was a valid property detected on the table entity?
							if (columnProperty == null)
							{
								// No. This is because a local variable was used instead of a "t.Column" styled call.
								var propName = p.Name;
								var anonymousEntityInstance = func.Invoke (dummyInstance);
								var propValue = p.GetValue (anonymousEntityInstance);

								// Prepare an SQL parameter corresponding to the local variable.
								var sqlParameter = new SqlQueryParameter (propName, propValue);
								this.AddToSqlQueryParameters (sqlParameter);

								// Add the table and column names to the list.
								this.columnsToSelect.Add
									(
										// Add the SQL parameter, instead of Table / Column info.
										new ColumnInfo
										{
											IsLocalVariable = true,
											SqlParameterForLocalVariable = sqlParameter
										}
									);
							}
							else
							{
								// Not a local variable, but an entity.Property statement.
								// Add the table and column names to the list.
								this.columnsToSelect.Add
									(
										new ColumnInfo
										{
											TableEntity = entityType,
											ColumnProperty = columnProperty
										}
									);
							}
						}
					);
			}
		}

		#endregion
	}
}