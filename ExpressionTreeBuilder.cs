namespace binaryExpressionTree.ExpressionTree
{
    public class ExpressionTreeBuilder
    {
        //taking Expression as Infix Expreexion
        //Convert Infix Exprssio to PostFix Expression
        //Creating PostFix Expression to Binary Expression Tree
        public static ExpressionNode BuildExpressionTree(string Expression)
        {

            var postFix = InfixToPostFix(Expression);
            int i = 0;
            string operators = "+*-/";
            var stack = new Stack<ExpressionNode>();
            while (i < postFix.Length)
            {
                var token = postFix[i++];
                if (operators.Contains(token))
                {
                    var rightNode = stack.Pop();
                    var leftNode = stack.Pop();
                    var operatorNode = OperatorNode.GetOperator(token);
                    operatorNode.Left = leftNode;
                    operatorNode.Right = rightNode;
                    stack.Push(operatorNode);
                }
                else
                {
                    stack.Push(new OperandNode(token.ToString()));
                }
            }

            return stack.Pop();
        }

        public static Dictionary<char, int> OperatorPrecedence = new Dictionary<char, int>() { { '+', 1 }, { '-', 1 }, { '/', 2 }, { '*', 2 } };
        public static string InfixToPostFix(string infixExpression)
        {
            var postFixExpression = new Queue<char>();
            var stack = new Stack<char>();
            if (!string.IsNullOrEmpty(infixExpression))
            {
                int i = 0;
                string operators = "+*-/";
                string brakets = "{[(}])";
                while (i < infixExpression.Length)
                {
                    var token = infixExpression[i++];
                    if (operators.Contains(token))
                    {
                        while (stack.Count() > 0 && !brakets.Contains(stack.Peek()) &&
                               OperatorPrecedence[stack.Peek()] >= OperatorPrecedence[token])
                        {
                            postFixExpression.Enqueue(stack.Pop());
                        }
                        stack.Push(token);
                    }
                    else if (brakets.Contains(token))
                    {
                        if (brakets.Substring(0, 3)
                                .Contains(token))
                        {
                            stack.Push(token);
                        }
                        else
                        {
                            var closeBracket = brakets.IndexOf(token);
                            var openBracket = brakets[closeBracket - 3];
                            while (stack.Peek() != openBracket)
                            {
                                postFixExpression.Enqueue(stack.Pop());
                            }
                            stack.Pop();
                        }
                    }
                    else
                    {
                        postFixExpression.Enqueue(token);
                    }

                }
                while (stack.Count() > 0)
                {
                    postFixExpression.Enqueue(stack.Pop());
                }
                string finalValue = null;
                postFixExpression.ToList().ForEach(postFixExpression => { finalValue = finalValue + postFixExpression; });
                return finalValue;
            }
            return string.Empty;
        }
        public static List<Token> getTokens(string infixExpression)
        {
            List<Token> tokens = new List<Token>();
            var stack = new Stack<char>();
            int index = 0;
            if (string.IsNullOrEmpty(infixExpression))
            {
                return tokens;
            }

            if (!string.IsNullOrEmpty(infixExpression))
            {
                int i = 0;
                string operators = "+*-/";
                string brakets = "{[(}])";

                while (i < infixExpression.Length)
                {
                    var text = infixExpression[i];
                    if (operators.Contains(text))
                    {
                        while (stack.Count() > 0 &&
                              !brakets.Contains(stack.Peek()) &&
                              OperatorPrecedence[stack.Peek()] >= OperatorPrecedence[text])
                        {

                            var poptext = stack.Pop();
                            var tokenNode = new Token()
                            {
                                index = index++,
                                text = poptext.ToString(),
                                isConstant = false,
                                isOperator = true
                            };
                            tokens.Add(tokenNode);
                        }
                        stack.Push(text);
                    }
                    else if (brakets.Contains(text))
                    {
                        if (brakets.Substring(0, 3).Contains(text))
                        {
                            stack.Push(text);
                        }
                        else
                        {
                            var closeBraketIndex = brakets.IndexOf(text);
                            var openBraket = brakets[closeBraketIndex - 3];
                            while (stack.Peek() != openBraket)
                            {
                                var poptext = stack.Pop();
                                var tokenNode = new Token()
                                {
                                    index = index++,
                                    text = poptext.ToString(),
                                    isConstant = false,
                                    isOperator = true
                                };
                                tokens.Add(tokenNode);
                            }
                            stack.Pop();
                        }
                    }
                    else if (char.IsLetter(text))
                    {
                        string feild = text.ToString();
                        while ((i + 1) < infixExpression.Length &&
                                (char.IsLetter(infixExpression[i + 1]) ||
                                infixExpression[i + 1] == '.'))
                        {
                            feild += infixExpression[++i];
                        }

                        var tokenNode = new Token()
                        {
                            index = index++,
                            text = feild,
                            isConstant = false,
                            isOperator = false,
                            value = null
                        };
                        tokens.Add(tokenNode);

                    }
                    else if (char.IsDigit(text) || text == '.')
                    {
                        string number = text.ToString();
                        while ((i + 1) < infixExpression.Length &&
                                (char.IsDigit(infixExpression[i + 1]) ||
                                infixExpression[i + 1] == '.'))
                        {
                            number += infixExpression[++i];
                        }
                        var tokenNode = new Token()
                        {
                            index = index++,
                            text = number,
                            isConstant = true,
                            isOperator = false,
                            value = decimal.Parse(number)
                        };
                        tokens.Add(tokenNode);
                    }
                    // if whitspace is there it is processased as increment


                    i++;
                }
                while (stack.Count() > 0)
                {
                    var poptext = stack.Pop();
                    var tokenNode = new Token()
                    {
                        index = index++,
                        text = poptext.ToString(),
                        isConstant = false,
                        isOperator = true
                    };
                    tokens.Add(tokenNode);
                }
            }

            return tokens.OrderBy(x => x.index).ToList();
        }
        public static ExpressionNode BuidExpressionTreeFromToken(string expression)
        {
            var postFix = InfixToPostFix(expression);
            var stack = new Stack<ExpressionNode>();
            var tokens = getTokens(expression);
            tokens.ForEach(token =>
            {
                if (token.isOperator)
                {
                    var rightNode = stack.Pop();
                    var leftNode = stack.Pop();
                    var operatorNode = OperatorNode.GetOperator(token.text[0]);
                    operatorNode.Left = leftNode;
                    operatorNode.Right = rightNode;
                    stack.Push(operatorNode);

                }
                else if (token.value.HasValue)
                {
                    stack.Push(new ConstantNode(token.value.Value));
                }
                else
                {
                    stack.Push(new OperandNode(token.text));
                }


            });
            return stack.Pop();
        }
    }
}



