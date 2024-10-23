using binaryExpressionTree.ExpressionTree;

namespace ExpressionTree.ExpressionTree
{
    public class TransformExpression
    {
        public static Func<Dictionary<string, decimal>, decimal> Eval(string expression)
        {
            var expressoinNode = ExpressionTreeBuilder.BuidExpressionTreeFromToken(expression);
            return (x) =>
            {
                return expressoinNode.Eval(x);
            };
        }
    }
}
