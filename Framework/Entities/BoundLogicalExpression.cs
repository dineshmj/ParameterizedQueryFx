using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using ParameterizedQuery.Framework.Extensions;

namespace ParameterizedQuery.Framework.Entities
{
	/// <summary>
	/// Represents a logically bound binary expression (using logical operators "and" or "or")
	/// that represents a WHERE clause condition.
	/// </summary>
	public sealed class BoundLogicalExpression
	{
		#region Properties.

		/// <summary>
		/// The logical operator.
		/// </summary>
		public LogicalOperator LogicalOperator { get; set; }

		/// <summary>
		/// The logical expression that represents a WHERE clause condition.
		/// </summary>
		public Expression LogicalExpression { get; set; }

		/// <summary>
		/// The sub-expressions of the logical expression. This list will have
		/// more than one element in it, if there are multiple boolean conditions
		/// that are joined together with "and" or "or" operator.
		/// </summary>
		public IList<BoundLogicalExpression> SubExpressions { get; }

		#endregion

		#region Constructors.

		/// <summary>
		/// Instantiates this class.
		/// </summary>
		/// <param name="logicalOperator">The logical operator that this expression binds
		/// with the previous expression.</param>
		/// <param name="logicalExpression">The logical expression that is to be bound to
		/// another logical expression.</param>
		public BoundLogicalExpression
			(
				LogicalOperator logicalOperator,
				Expression logicalExpression
			)
		{
			// Indicator for a single-condition of ".In ()" or ".NotIn ()" call situation.
			var onelyOneConditionWithInOrNotInCallDetected = false;

			// Set the instance fields.
			this.LogicalOperator = logicalOperator;
			this.LogicalExpression = logicalExpression;

			// Prepare the sub-expressions list.
			this.SubExpressions = new List<BoundLogicalExpression> ();
			var individualConditions = new List<Tuple<LogicalOperator, Expression>> ();

			// Is the expression a boolean expression?
			if (logicalExpression is BinaryExpression)
			{
				// Yes.
				var expression = (BinaryExpression) logicalExpression;

				// Get the parts of the expression.
				var leftSide = expression.Left; // Left side.
				var rightSide = expression.Right; // Right side.
				var joinedBy = expression.NodeType; // Logical operator in between.
				var equivLogicalOperator = this.GetLogicalOperatorFrom (joinedBy); // Equivalent logical operator as "And" or "Or".

				// Is it "And" or "Or" operator?
				if (equivLogicalOperator.In (LogicalOperator.And, LogicalOperator.Or))
				{
					// Yes. Add the left and right to the list.
					individualConditions.Insert (0, new Tuple<LogicalOperator, Expression> (equivLogicalOperator, rightSide));
					individualConditions.Insert (0, new Tuple<LogicalOperator, Expression> (LogicalOperator.None, leftSide));
				}
			}
			else
			{
				// There is only one condition, and that is either an ".In ()" or ".NotIn ()" call.
				onelyOneConditionWithInOrNotInCallDetected = true;
			}

			// Is there only one conditon, of ".In ()" or ".NotIn ()" call type?
			if (onelyOneConditionWithInOrNotInCallDetected)
			{
				// Yes.
				this.SubExpressions.Add (this);
			}
			else
			{
				// For both sides, find the sub-expressions.
				foreach (var oneExpression in individualConditions)
				{
					this.SubExpressions.Add (new BoundLogicalExpression (oneExpression.Item1, oneExpression.Item2));
				}
			}
		}

		#endregion

		#region Private methods.

		/// <summary>
		/// Gets the logical operation from the expression type.
		/// </summary>
		/// <param name="expType">The expression type.</param>
		/// <returns></returns>
		private LogicalOperator GetLogicalOperatorFrom (ExpressionType expType)
		{
			switch (expType)
			{
				case ExpressionType.AndAlso:
					return (LogicalOperator.And);

				case ExpressionType.OrElse:
					return (LogicalOperator.Or);

				default:
					return (LogicalOperator.None);
			}
		}

		#endregion
	}
}