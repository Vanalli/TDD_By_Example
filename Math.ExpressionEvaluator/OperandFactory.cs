using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class OperandFactory : IOperandFactory
    {
        public Operand Create(int value)
        {
            return new Operand(value);
        }
    }
}
