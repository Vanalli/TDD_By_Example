using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class Parser
    {
        private readonly OperatorFactory operatorFactory;
        private readonly IOperandFactory operandFactory;

        public Parser(OperatorFactory operatorFactory, IOperandFactory operandFactory)
        {
            this.operatorFactory = operatorFactory;
            this.operandFactory = operandFactory;
        }

        public IEnumerable<Element> Parse(String s)
        {
            var operand = "";
            foreach (var currentChar in s)
            {
                if (char.IsDigit(currentChar))
                    operand += currentChar;
                else
                {
                    //yield return new Operand(Convert.ToInt32(s));
                    yield return operandFactory.Create(Convert.ToInt32(operand));
                    operand = "";
                    yield return operatorFactory.Create(currentChar);
                }
            }
            if (operand != "")
                yield return operandFactory.Create(Convert.ToInt32(operand));
        }
    }
}
