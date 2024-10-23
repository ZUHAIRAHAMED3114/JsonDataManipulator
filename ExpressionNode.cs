namespace binaryExpressionTree.ExpressionTree
{
    public abstract class ExpressionNode
    {
        public abstract decimal Eval(Dictionary<string, decimal> keyValuePairs);
        public string ToString()
        {
            if (this is OperandNode)
                return ((OperandNode)this).Name.ToString();
            else if (this is ConstantNode)
                return ((ConstantNode)this).Value.ToString();
            else if (this is OperatorNode)
            {
                var operatorNode = (OperatorNode)this;
                return $"{operatorNode.Left.ToString()}{operatorNode.oper.ToString()}{operatorNode.Right.ToString()}";
            }
            return string.Empty;
        }
    }
}
