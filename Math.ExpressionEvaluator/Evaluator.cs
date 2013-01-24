using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class Evaluator
    {
        public int Eval(String s)
        {
            if (String.IsNullOrEmpty(s))
            {
                throw new InvalidOperationException();
            }

            var parser = new Parser();
            var elements = parser.Parse(s).ToList();

            if (elements.Count == 3)
            {
                var left = elements[0] as Operand;
                var op = elements[1] as Operator;
                var right = elements[2] as Operand;
                return op.Compute(left, right);
           } 
            return Convert.ToInt32(s);
        }
    }
}
