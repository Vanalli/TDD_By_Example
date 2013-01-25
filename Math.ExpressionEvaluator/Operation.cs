using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class Operation
    {
        public Operand LOperand { get; private set; }
        public Operator Op { get; private set; }
        public Operand ROperand { get; private set; }

        public Operation(Operand lOperand, Operator op, Operand rOperand)
        {
            LOperand = lOperand;
            Op = op;
            ROperand = rOperand;
        }

        public Operand Compute()
        {
            return new Operand(Op.Compute(LOperand, ROperand));
        }
    }
}
