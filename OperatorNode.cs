using ExpressionTree.ExpressionTree;
using System.Numerics;

namespace binaryExpressionTree.ExpressionTree
{
    public abstract class OperatorNode : ExpressionNode
    {
        public readonly char oper;
        public ExpressionNode? Left { get; set; }
        public ExpressionNode? Right { get; set; }
        protected decimal leftValue;
        protected decimal rightValue;
        public OperatorNode(char oper)
        {
            this.oper = oper;
        }
        protected void GetChildNodesValues(Dictionary<string, decimal> keyValuePairs) {
            leftValue = Left.Eval(keyValuePairs);
            rightValue = Right.Eval(keyValuePairs);
        }
       public static OperatorNode GetOperator(char oper)
        {
            return oper switch
            {
                '+' => new AdditionOperatorNode(oper),
                '-' => new SubtractionOperatorNode(oper),
                '*' => new MultiplicationOperatorNode(oper),
                '/' => new DivisionOperatorNode(oper),
                _ => throw new ArgumentException("Invalid Operator")
            };

        }
       
    }
}
