using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperandTests
    {
        [TestMethod]
        public void Constructor_Sets_Value_Property_Correctly()
        {
            var sut = new Operand(123);
            Assert.AreEqual(123, sut.Value);
        }
    }
}
