namespace binaryExpressionTree.ExpressionTree
{
    public class Token
    {
        public int index { get; set; }
        public string text { get; set; }
        public bool isOperator { get; set; }
        public bool isConstant { get; set; }
        public decimal? value { get; set; }
    }
}
