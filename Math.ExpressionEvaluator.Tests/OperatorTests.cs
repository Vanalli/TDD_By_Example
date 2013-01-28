using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void Add_Operator_Precedence_Is_Set_Correctly()
        {
            var sut = new AddOperator();
            Assert.AreEqual(1, sut.Precedence);
        }

        [TestMethod]
        public void Operator_Precedence_Is_Set_Correctly()
        {
            Assert.AreEqual(1, new AddOperator().Precedence);
            Assert.AreEqual(1, new SubOperator().Precedence);
            Assert.AreEqual(2, new MulOperator().Precedence);
            Assert.AreEqual(2, new DivOperator().Precedence);
        }
    }
}
