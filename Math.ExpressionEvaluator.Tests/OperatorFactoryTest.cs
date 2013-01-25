using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class OperatorFactoryTest
    {
        private OperatorFactory sut;

        [TestInitialize]
        public void SetUp()
        {
            sut = new OperatorFactory();
        }

        [TestMethod]
        public void Plus_Sign_Returns_AddOperator()
        {
            Check('+', typeof(AddOperator));
        }

        [TestMethod]
        public void Minus_Sign_Returns_SubOperator()
        {
            Check('-',typeof(SubOperator));
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void Unknown_Sign_Throws_Exception()
        {
            sut.Create('x');
        }

        [TestMethod]
        public void Asterisk_Sign_Returns_MulOperator()
        {
            Check('*', typeof(MulOperator));
        }

        [TestMethod]
        public void Slash_Sign_Returns_DivOperator()
        {
            Check('/', typeof(DivOperator));
        }

        private void Check(char op, Type type)
        {
            var result = sut.Create(op);
            Assert.IsInstanceOfType(result, type);
        }
    }
}
