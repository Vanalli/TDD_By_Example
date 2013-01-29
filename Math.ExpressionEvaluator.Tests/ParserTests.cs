using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Math.ExpressionEvaluator.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ParserTests
    {
        public ParserTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Parser_Returns_Addition_Elements()
        {
            var sut = new Parser(new OperatorFactory(), new OperandFactory());
            var result = sut.Parse("1+2").ToList();
            Assert.AreEqual(3, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(Operand));
            Assert.IsInstanceOfType(result[1], typeof(Operator));
            Assert.IsInstanceOfType(result[2], typeof(Operand));
        }

        [TestMethod]
        public void Parse_Calls_Operand_Factory_Create()
        {
            var operandFactory = new Mock<IOperandFactory>();
            operandFactory
                .Setup(it => it.Create(It.IsAny<int>()))
                .Verifiable();
            var sut = new Parser(new OperatorFactory(), operandFactory.Object);
            sut.Parse("1").ToList();
            operandFactory.Verify();
        }

        [TestMethod]
        public void NegativeNumber()
        {
            var sut = new Parser(new OperatorFactory(), new OperandFactory());
            var result = sut.Parse("-3").ToList();
            Assert.AreEqual(2, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(SubOperator));
            Assert.AreEqual(3, ((Operand)result[1]).Value);
        }
    }
}
