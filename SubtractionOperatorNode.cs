using binaryExpressionTree.ExpressionTree;

namespace ExpressionTree.ExpressionTree
{
    public class SubtractionOperatorNode : OperatorNode
    {
        public SubtractionOperatorNode(char oper) : base(oper)
        {
        }

        public override decimal Eval(Dictionary<string, decimal> keyValuePairs)
        {
            base.GetChildNodesValues(keyValuePairs);
            return leftValue - rightValue;
        }
    }
}
