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
            string[] parts;
            if (s.IndexOf('+') >= 0)
            {
                var parts = s.Split('+');
                return parts
                    .Select(part => Convert.ToInt32(part))
                    .Sum();
            }
            else if(s.IndexOf('-') >= 0)
            {
                var parts
            }
        }
    }
}
