using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperandFactoryTest
    {
        [TestMethod]
        public void Create_Returns_Operand()
        {
            var sut = new OperandFactory();
            var result = sut.Create(5);
            Assert.IsInstanceOfType(result, typeof(Operand));
        }

        [TestMethod]
        public void Create_Returns_Operand_With_Correct_Value()
        {
            var sut = new OperandFactory();
            var result = sut.Create(5);
            Assert.AreEqual(5, result.Value);
        }
    }
}
