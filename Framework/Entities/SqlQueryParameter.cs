using System;
using System.Data;
using System.Text;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents a T-SQL parameter.
	/// </summary>
	public sealed class SqlQueryParameter
	{
		#region Properties.

		/// <summary>
		/// The name of the T-SQL parameter.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// The T-SQL DB type.
		/// </summary>
		public SqlDbType DbType { get; private set; }

		/// <summary>
		/// The T-SQL parameter value.
		/// </summary>
		public string Value { get; private set; }

		#endregion

		#region Constructors.

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="localVariableName">The name of the SQL parameter.</param>
		/// <param name="localVariableValue">The value of the SQL parameter.</param>
		public SqlQueryParameter (string localVariableName, object localVariableValue)
		{
			// Set the name.
			this.Name = "@param_" + localVariableName;

			// Set the SQL DB type, and value.
			if (localVariableValue is short || localVariableValue is int || localVariableValue is long)
			{
				this.Value = localVariableValue.ToString ();
				this.DbType = SqlDbType.BigInt;
			}
			else if (localVariableValue is char)
			{
				this.Value = localVariableValue.ToString ();
				this.DbType = SqlDbType.Char;
			}
			else if (localVariableValue is string)
			{
				this.Value = (string) localVariableValue;
				this.DbType = SqlDbType.NVarChar;
			}
			else if (localVariableValue is DateTime)
			{
				this.Value = ((DateTime) localVariableValue).ToString ("dd-MMM-yyyy");
				this.DbType = SqlDbType.DateTime;
			}
		}

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="value">The value of the T-SQL parameter.</param>
		/// <param name="dbType">The DB type of the parameter.</param>
		public SqlQueryParameter (string value, SqlDbType dbType)
		{
			// Deduce the name of the parameter from value.
			this.Name = this.ExtractAndSetParamNameFromValue (value);
			this.Value = value;
			this.DbType = dbType;
		}

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="paramName">The name of the T-SQL parameter.</param>
		/// <param name="value">The value of the T-SQL parameter.</param>
		/// <param name="dbType">The DB type of the parameter.</param>
		public SqlQueryParameter (string paramName, string value, SqlDbType dbType)
		{
			// Set the instance fields with the values specified.
			this.Name = paramName;
			this.Value = value;
			this.DbType = dbType;
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Extracts and sets value for the T-SQL parameter. This constructor is suitable if you
		/// have constant values in the T-SQL query statement (such as, 'A', 'John', etc.), and you don't
		/// need to deduce a suitable name for the T-SQL parameter representing the constant.
		/// </summary>
		/// <param name="value">The value of the parameter, from which the name of
		/// the T-SQL parameter is to be deduced.</param>
		private string ExtractAndSetParamNameFromValue (string value)
		{
			var builder = new StringBuilder ();

			// Extract only the English alphabetic characters from the parameter value.
			foreach (var oneChar in value)
			{
				// Only characters from 'A' through 'Z', and  'a' through  'z'.
				if ((oneChar >= 'A' && oneChar <= 'Z') || (oneChar >= 'a' || oneChar <= 'z'))
				{
					builder.Append (oneChar);
				}
			}

			// Form the automatic name for the parameter.
			return ("@paramValue_" + builder);
		}

		#endregion
	}
}