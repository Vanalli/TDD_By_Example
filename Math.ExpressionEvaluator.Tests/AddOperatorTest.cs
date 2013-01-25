using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class AddOperatorTest
    {
        [TestMethod]
        public void AddOperator_Computes_Correct_Value()
        {
            var sut = new AddOperator();
            var result = sut.Compute(new Operand(10), new Operand(20));
            Assert.AreEqual(30, result);
        }
    }
}
