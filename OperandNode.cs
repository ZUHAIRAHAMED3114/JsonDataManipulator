namespace binaryExpressionTree.ExpressionTree
{
    public class OperandNode : ExpressionNode
    {
        public string Name { get; private set; }
        public OperandNode(string name)
        {
            Name = name;
        }

        public override decimal Eval(Dictionary<string, decimal> keyValuePairs)
        {
            if (keyValuePairs.ContainsKey(Name))
            {
                return keyValuePairs[Name];
            }
            throw new ArgumentException($"Variable {Name} not found");
        }
    }
}
