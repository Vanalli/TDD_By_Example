using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class ElementList
    {
        private readonly IList<Element> elements;

        public Operand First
        {
            get { return elements[0] as Operand; }
        }

        public ElementList(IEnumerable<Element> elements)
        {
            this.elements = new List<Element>(elements);
        }

        public Operation FindOperation()
        {
            var maxPrecOperator = elements
                .Where(el => el is Operator)
                .OrderByDescending(el => ((Operator)el).Precedence)
                .FirstOrDefault() as Operator;

            if (maxPrecOperator == null)
                return null;

            var index = elements.IndexOf(maxPrecOperator);
            return new Operation(elements[index - 1] as Operand, elements[index] as Operator, elements[index + 1] as Operand);

            //for (var i = 0; i < elements.Count; i++)
            //    if (elements[i] is Operator)
            //        return new Operation(
            //            elements[i - 1] as Operand,
            //            elements[i] as Operator,
            //            elements[i + 1] as Operand);
            //return null;
        }

        public void ReplaceOperation(Operation operation, Operand operand)
        {
            var index = elements.IndexOf(operation.LOperand);
            elements.RemoveAt(index + 2);
            elements.RemoveAt(index + 1);
            elements[index] = operand;
        }
    }
}
