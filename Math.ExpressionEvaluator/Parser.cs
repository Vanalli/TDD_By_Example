using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class Parser
    {
        public IEnumerable<Element> Parse(String s)
        {
            var operatorFactory = new OperatorFactory();
            var operand = "";
            foreach (var currentChar in s)
            {
                if (char.IsDigit(currentChar))
                    operand += currentChar;
                else
                {
                    yield return new Operand(operand);
                    operand = "";
                    yield return operatorFactory.Create(currentChar);
                }
            }
            if (operand != "")
                yield return new Operand(operand);
        }
    }
}
