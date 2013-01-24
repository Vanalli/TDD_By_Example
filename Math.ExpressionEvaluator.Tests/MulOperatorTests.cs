using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class MulOperatorTests
    {
        [TestMethod]
        public void MulOperator_Computes_Correct_Value()
        {
            var sut = new MulOperator();
            var result = sut.Compute(new Operand("10"), new Operand("25"));
            Assert.AreEqual(250, result);
        }
    }
}
