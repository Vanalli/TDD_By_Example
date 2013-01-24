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
        public void Plus_Sigh_Returns_AddOperator()
        {
            var sut = new OperatorFactory();
            Check('+', typeof(AddOperator));
        }

        [TestMethod]
        public void Minus_Sig_nReturns_SubOperator()
        {
            var sut = new OperatorFactory();
            Check('-',typeof(SubOperator));
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void Unknown_Sign_Throws_Exception()
        {
            var sut = new OperatorFactory();
            sut.Create('x');
        }

        [TestMethod]
        public void Asterisk_Sign_Returns_MulOperator()
        {
            var sut = new OperatorFactory();
            Check('*', typeof(MulOperator));
        }

        private void Check(char op, Type type)
        {
            var result = sut.Create('+');
            Assert.IsInstanceOfType(result, type);
        }
    }
}
