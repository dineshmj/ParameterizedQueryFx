using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
		#region Private instance fields.

		/// <summary>
		/// A dictionary of the aliases of table entities, vs. their real entity types.
		/// </summary>
		private readonly IDictionary<string, Type> tableAliasesDictionary;

		#endregion

		#region Methods.

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1> (string a1)
		{
			// Get the generic types.
			var t1 = typeof (T1);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2> (string a1, string a2)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3> (string a1, string a2, string a3)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4> (string a1, string a2, string a3, string a4)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5> (string a1, string a2, string a3, string a4, string a5)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <typeparam name="T9">The generic entity type of the ninth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <param name="a9">The alias of the ninth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8, T9>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8, string a9
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);
			var t9 = typeof (T9);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);
			this.AddAliases (t9, a9);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <typeparam name="T9">The generic entity type of the ninth table.</typeparam>
		/// <typeparam name="T10">The generic entity type of the tenth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <param name="a9">The alias of the ninth table.</param>
		/// <param name="a10">The alias of the tenth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8, string a9, string a10
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);
			var t9 = typeof (T9);
			var t10 = typeof (T10);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);
			this.AddAliases (t9, a9);
			this.AddAliases (t10, a10);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <typeparam name="T9">The generic entity type of the ninth table.</typeparam>
		/// <typeparam name="T10">The generic entity type of the tenth table.</typeparam>
		/// <typeparam name="T11">The generic entity type of the eleventh table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <param name="a9">The alias of the ninth table.</param>
		/// <param name="a10">The alias of the tenth table.</param>
		/// <param name="a11">The alias of the eleventh table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8, string a9, string a10,
				string a11
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);
			var t9 = typeof (T9);
			var t10 = typeof (T10);
			var t11 = typeof (T11);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);
			this.AddAliases (t9, a9);
			this.AddAliases (t10, a10);
			this.AddAliases (t11, a11);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <typeparam name="T9">The generic entity type of the ninth table.</typeparam>
		/// <typeparam name="T10">The generic entity type of the tenth table.</typeparam>
		/// <typeparam name="T11">The generic entity type of the eleventh table.</typeparam>
		/// <typeparam name="T12">The generic entity type of the twelfth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <param name="a9">The alias of the ninth table.</param>
		/// <param name="a10">The alias of the tenth table.</param>
		/// <param name="a11">The alias of the eleventh table.</param>
		/// <param name="a12">The alias of the twelfth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8, string a9, string a10,
				string a11, string a12
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);
			var t9 = typeof (T9);
			var t10 = typeof (T10);
			var t11 = typeof (T11);
			var t12 = typeof (T12);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);
			this.AddAliases (t9, a9);
			this.AddAliases (t10, a10);
			this.AddAliases (t11, a11);
			this.AddAliases (t12, a12);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <typeparam name="T9">The generic entity type of the ninth table.</typeparam>
		/// <typeparam name="T10">The generic entity type of the tenth table.</typeparam>
		/// <typeparam name="T11">The generic entity type of the eleventh table.</typeparam>
		/// <typeparam name="T12">The generic entity type of the twelfth table.</typeparam>
		/// <typeparam name="T13">The generic entity type of the thirteenth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <param name="a9">The alias of the ninth table.</param>
		/// <param name="a10">The alias of the tenth table.</param>
		/// <param name="a11">The alias of the eleventh table.</param>
		/// <param name="a12">The alias of the twelfth table.</param>
		/// <param name="a13">The alias of the thirteenth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8, string a9, string a10,
				string a11, string a12, string a13
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);
			var t9 = typeof (T9);
			var t10 = typeof (T10);
			var t11 = typeof (T11);
			var t12 = typeof (T12);
			var t13 = typeof (T13);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);
			this.AddAliases (t9, a9);
			this.AddAliases (t10, a10);
			this.AddAliases (t11, a11);
			this.AddAliases (t12, a12);
			this.AddAliases (t13, a13);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <typeparam name="T9">The generic entity type of the ninth table.</typeparam>
		/// <typeparam name="T10">The generic entity type of the tenth table.</typeparam>
		/// <typeparam name="T11">The generic entity type of the eleventh table.</typeparam>
		/// <typeparam name="T12">The generic entity type of the twelfth table.</typeparam>
		/// <typeparam name="T13">The generic entity type of the thirteenth table.</typeparam>
		/// <typeparam name="T14">The generic entity type of the fourteenth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <param name="a9">The alias of the ninth table.</param>
		/// <param name="a10">The alias of the tenth table.</param>
		/// <param name="a11">The alias of the eleventh table.</param>
		/// <param name="a12">The alias of the twelfth table.</param>
		/// <param name="a13">The alias of the thirteenth table.</param>
		/// <param name="a14">The alias of the fourteenth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8, string a9, string a10,
				string a11, string a12, string a13, string a14
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);
			var t9 = typeof (T9);
			var t10 = typeof (T10);
			var t11 = typeof (T11);
			var t12 = typeof (T12);
			var t13 = typeof (T13);
			var t14 = typeof (T14);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);
			this.AddAliases (t9, a9);
			this.AddAliases (t10, a10);
			this.AddAliases (t11, a11);
			this.AddAliases (t12, a12);
			this.AddAliases (t13, a13);
			this.AddAliases (t14, a14);

			return (this);
		}

		/// <summary>
		/// Registers the aliases of the specified generic types of entities that would
		/// appear as tables in the parameterized query.
		/// </summary>
		/// <typeparam name="T1">The generic entity type of the first table.</typeparam>
		/// <typeparam name="T2">The generic entity type of the second table.</typeparam>
		/// <typeparam name="T3">The generic entity type of the third table.</typeparam>
		/// <typeparam name="T4">The generic entity type of the fourth table.</typeparam>
		/// <typeparam name="T5">The generic entity type of the fifth table.</typeparam>
		/// <typeparam name="T6">The generic entity type of the sixth table.</typeparam>
		/// <typeparam name="T7">The generic entity type of the seventh table.</typeparam>
		/// <typeparam name="T8">The generic entity type of the eighth table.</typeparam>
		/// <typeparam name="T9">The generic entity type of the ninth table.</typeparam>
		/// <typeparam name="T10">The generic entity type of the tenth table.</typeparam>
		/// <typeparam name="T11">The generic entity type of the eleventh table.</typeparam>
		/// <typeparam name="T12">The generic entity type of the twelfth table.</typeparam>
		/// <typeparam name="T13">The generic entity type of the thirteenth table.</typeparam>
		/// <typeparam name="T14">The generic entity type of the fourteenth table.</typeparam>
		/// <typeparam name="T15">The generic entity type of the fifteenth table.</typeparam>
		/// <param name="a1">The alias of the first table.</param>
		/// <param name="a2">The alias of the second table.</param>
		/// <param name="a3">The alias of the third table.</param>
		/// <param name="a4">The alias of the fourth table.</param>
		/// <param name="a5">The alias of the fifth table.</param>
		/// <param name="a6">The alias of the sixth table.</param>
		/// <param name="a7">The alias of the seventh table.</param>
		/// <param name="a8">The alias of the eighth table.</param>
		/// <param name="a9">The alias of the ninth table.</param>
		/// <param name="a10">The alias of the tenth table.</param>
		/// <param name="a11">The alias of the eleventh table.</param>
		/// <param name="a12">The alias of the twelfth table.</param>
		/// <param name="a13">The alias of the thirteenth table.</param>
		/// <param name="a14">The alias of the fourteenth table.</param>
		/// <param name="a15">The alias of the fifteenth table.</param>
		/// <returns></returns>
		public ParameterizedSqlQuery TableAliasesAs<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
			(
				string a1, string a2, string a3, string a4, string a5,
				string a6, string a7, string a8, string a9, string a10,
				string a11, string a12, string a13, string a14, string a15
			)
		{
			// Get the generic types.
			var t1 = typeof (T1);
			var t2 = typeof (T2);
			var t3 = typeof (T3);
			var t4 = typeof (T4);
			var t5 = typeof (T5);
			var t6 = typeof (T6);
			var t7 = typeof (T7);
			var t8 = typeof (T8);
			var t9 = typeof (T9);
			var t10 = typeof (T10);
			var t11 = typeof (T11);
			var t12 = typeof (T12);
			var t13 = typeof (T13);
			var t14 = typeof (T14);
			var t15 = typeof (T15);

			// Add the generic types and aliases.
			this.AddAliases (t1, a1);
			this.AddAliases (t2, a2);
			this.AddAliases (t3, a3);
			this.AddAliases (t4, a4);
			this.AddAliases (t5, a5);
			this.AddAliases (t6, a6);
			this.AddAliases (t7, a7);
			this.AddAliases (t8, a8);
			this.AddAliases (t9, a9);
			this.AddAliases (t10, a10);
			this.AddAliases (t11, a11);
			this.AddAliases (t12, a12);
			this.AddAliases (t13, a13);
			this.AddAliases (t14, a14);
			this.AddAliases (t15, a15);

			return (this);
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Adds the alias for the specified table etntity.
		/// </summary>
		/// <param name="tableType">The entity that represents the DB table.</param>
		/// <param name="alias">The alias for the table entity.</param>
		private void AddAliases (Type tableType, string alias)
		{
			// Has the alias been already used for a different table?
			if (this.tableAliasesDictionary.ContainsKey (alias))
			{
				// Yes.
				throw (new ParameterizedQueryException ("The specified alias, \"" + alias + "\" has already been used for a different table entity."));
			}

			// Add the alias for the table entity.
			this.tableAliasesDictionary.Add (alias, tableType);
		}

		#endregion
	}
}