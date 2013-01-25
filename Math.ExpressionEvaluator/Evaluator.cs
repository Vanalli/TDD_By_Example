using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class Evaluator
    {
        private readonly Parser parser;

        public Evaluator(Parser parser)
        {
            this.parser = parser;
        }

        public int Eval(String s)
        {
            if (String.IsNullOrEmpty(s))
                throw new InvalidOperationException();

            var elements = parser.Parse(s).ToList();

            // if (elements.Count == 3)
            // {
            //     var left = elements[0] as Operand;
            //     var op = elements[1] as Operator;
            //     var right = elements[2] as Operand;
            //     return op.Compute(left, right);
            //} 
            // return Convert.ToInt32(s);

            while (elements.Count > 1)
            {
                var tuple = FindOperation(elements);
                var newElement = tuple.Item2.Compute();
                ReplaceOperation(elements, tuple.Item1, newElement);
            }

            return (elements[0] as Operand).Value;           
        }

        private static Tuple<int, Operation> FindOperation(List<Element> elements)
        {
            for (var i = 0; i < elements.Count; i++)
                if (elements[i] is Operator)
                    return new Tuple<int, Operation>(i - 1, new Operation(elements[i - 1] as Operand, elements[i] as Operator, elements[i + 1] as Operand));
            return null;
        }

        private static void ReplaceOperation(IList elements, int index, Operand operand)
        {
            elements.RemoveAt(index + 2);
            elements.RemoveAt(index + 1);
            elements.RemoveAt(index);
            elements.Insert(index, operand);
        }
    }
}

