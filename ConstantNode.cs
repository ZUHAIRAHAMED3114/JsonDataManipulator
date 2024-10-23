namespace binaryExpressionTree.ExpressionTree
{
    public class ConstantNode : ExpressionNode
    {
        public decimal Value { get; private set; }
        public ConstantNode(decimal value)
        {
            Value = value;
        }
        public override decimal Eval(Dictionary<string, decimal> keyValuePairs)
        {
            return Value;
        }
    }
}
