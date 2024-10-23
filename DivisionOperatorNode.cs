using binaryExpressionTree.ExpressionTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree.ExpressionTree
{
    public class DivisionOperatorNode: OperatorNode
    {
        public DivisionOperatorNode(char oper) : base(oper)
        {
        }

        public override decimal Eval(Dictionary<string, decimal> keyValuePairs)
        {
            base.GetChildNodesValues(keyValuePairs);
            return leftValue / rightValue;
        }
    }
}
