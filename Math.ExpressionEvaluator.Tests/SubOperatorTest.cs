using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class SubOperatorTest
    {
        [TestMethod]
        public void SubOperator_Computes_Correct_Values()
        {
            var sut = new SubOperator();
            var result = sut.Compute(new Operand("30"), new Operand("20"));
            Assert.AreEqual(10, result);
        }
    }
}
