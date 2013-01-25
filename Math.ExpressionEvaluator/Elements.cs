using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Math.ExpressionEvaluator
{
    public abstract class Element
    {
        public int Value { get; protected set; }
    }

    public class Operand : Element
    {
        public Operand(int operand)
        {
            this.Value = Convert.ToInt32(operand);
        }
    }

    public abstract class Operator : Element
    {
        public abstract int Compute(Operand left, Operand right);
    }
}
