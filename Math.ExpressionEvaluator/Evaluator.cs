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

            var elements = new ElementList(parser.Parse(s));
            var operation = elements.FindOperation();

            while (operation != null)
            {
                var newElement = operation.Compute();
                elements.ReplaceOperation(operation, newElement);
                operation = elements.FindOperation();
            }

            return elements.First.Value;
        }
    }
}

