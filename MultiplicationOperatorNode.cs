using binaryExpressionTree.ExpressionTree;

namespace ExpressionTree.ExpressionTree
{
    public class MultiplicationOperatorNode : OperatorNode
    {
        public MultiplicationOperatorNode(char oper) : base(oper)
        {
        }

        public override decimal Eval(Dictionary<string, decimal> keyValuePairs)
        {
            base.GetChildNodesValues(keyValuePairs);
            return leftValue * rightValue;
        }
    }
}
