using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public class OperatorFactory
    {
        public Operator Create(char op)
        {
            switch (op)
            {
                case '+':
                    return new AddOperator();
                case '-':
                    return new SubOperator();
                case '*':
                    return new MulOperator();
                case '/':
                    return new DivOperator();
                default:
                    throw new InvalidOperationException(string.Format("Unknown operator [{0}]", op));
            }
        }
    }

    public class AddOperator : Operator
    {
        public override int Compute(Operand left, Operand right)
        {
            return left.Value + right.Value;
        }   
    }

    public class SubOperator : Operator
    {
        public override int Compute(Operand left, Operand right)
        {
            return left.Value - right.Value;
        }
    }

    public class MulOperator : Operator
    {
        public override int Compute(Operand left, Operand right)
        {
            return left.Value * right.Value;
        }
    }

    public class DivOperator : Operator
    {
        public override int Compute(Operand left, Operand right)
        {
            return left.Value / right.Value;
        }
    }
}
