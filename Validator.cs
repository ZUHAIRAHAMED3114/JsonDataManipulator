using binaryExpressionTree.ExpressionTree;
using System.Text.RegularExpressions;

namespace ExpressionTree.Validate
{
    public class Validator
    {
        public static bool isValid(string exprssion)
        {
            var operators = OperatorNode.GetAvaialableOperator();
            return false;
        }
        public static bool IsSpecialCharacters(string inputExpresoin) 
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z.+\-*/()\s]+$");
            return regex.IsMatch(inputExpresoin);
        }
        public static bool LevelOfOpration(string expression, int level) 
        {
            var  tokens = ExpressionTreeBuilder.getInfixTokens(expression);
            return  tokens.ToList().Where(x => x.isOperator).Count() <= level;
        }
        public static bool isExplicitExpression(string expression) 
        {
            var tokens=ExpressionTreeBuilder.getInfixTokens(expression);
            int i = 0;
            int length=tokens.Count()-1;
            string openParenthessis = "{[(";
            string closeParenthesis = ")]}";
            while (i < tokens.Count) 
            {
                if (i != 0 && tokens[i].isParenthesis
                           && openParenthessis.Contains(tokens[i].text)) 
                {
                    var previousToken = tokens[i-1];
                     if (!previousToken.isOperator)
                        return false;
                }
                if (i != length && tokens[i].isOperator
                             && closeParenthesis.Contains(tokens[i].text)) 
                {
                    var nextToken=tokens[i+1];
                    if (!nextToken.isOperator)
                        return false;
                }
                i++;
            }
         
            return true;
        }
        public static bool isOperatorPositionValid(string expression) 
        {
            string openParenthessis = "{[(";
            string closeParenthesis = ")]}";

            var tokens = ExpressionTreeBuilder.getInfixTokens(expression);
            int i = 1;
            if (tokens[0].isOperator)
                return false;
            if (tokens[tokens.Count()-1].isOperator)
                return false;
            while (i < tokens.Count() - 1) 
            {
                var token = tokens[i];
                if (token.isOperator)
                {
                    var previousToken = tokens[i - 1];
                    var nextToken = tokens[i + 1];
                    if (previousToken.isOperator ||
                       (previousToken.isParenthesis && openParenthessis.Contains(previousToken.text)))
                    {
                        return false;
                    }

                    if (nextToken.isOperator ||
                         (nextToken.isParenthesis &&
                         closeParenthesis.Contains(nextToken.text)))
                    {
                        return false;
                    }
                }
                i++;
            }
            return true;
        }
        public static bool IsBalancedParentheses(string expression)
        {
             
            int i = 0;
            string openParenthessis = "{[(";
            string closeParenthesis = "}])";
            var stack=new Stack<char>(); 

            while (i < expression.Length) 
            {
                if (openParenthessis.Contains(expression[i])) 
                {
                    stack.Push(expression[i]);
                }
                if (closeParenthesis.Contains(expression[i])) 
                {
                    var openParanthe = openParenthessis[closeParenthesis.IndexOf(expression[i])];
                    
                    if ((stack.Count()==0) ||
                        (stack.Pop() != openParanthe)) 
                    {
                        return false;
                    }
                }
                i++;            
            }
            return stack.Count==0;
        }
        // Operator Count + Operatnd Count Validation Pending...?
    }
}
