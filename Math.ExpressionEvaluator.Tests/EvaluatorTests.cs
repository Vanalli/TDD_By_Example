using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class EvaluatorTests
    {
        public EvaluatorTests()
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

        public static void CheckEvaluation(string s, int expected)
        {
            var parser = new Parser(new OperatorFactory(), new OperandFactory());
            var sut = new Evaluator(parser);
            var result = sut.Eval(s);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void String_Vazia_Ou_Nula_Deve_Retornar_Exception()
        {
            var parser = new Parser(new OperatorFactory(), new OperandFactory());
            var sut = new Evaluator(parser);
            sut.Eval(String.Empty);
        }

        [TestMethod]
        public void Numero_De_Um_Digito_E_Avaliado_Como_Seu_Valor_Inteiro()
        {
            CheckEvaluation("7", 7);
        }

        [TestMethod]
        public void Numero_De_Um_Digito_E_Avaliado_Como_Seu_Valor_Inteiro_Segunda_Tentativa()
        {
            CheckEvaluation("5", 5);
        }

        [TestMethod]
        public void Numero_De_Multiplos_Digitos_E_Avaliado_Como_Seu_Valor_Inteiro()
        {
            CheckEvaluation("324", 324);
        }

        [TestMethod]
        public void Adicionando_Dois_Numeros()
        {
            CheckEvaluation("1+2", 3);
        }

        [TestMethod]
        public void Subtraindo_Dois_Numeros()
        {
            CheckEvaluation("88-20", 68);
        }

        [TestMethod]
        public void Can_Multiply_Two_Integer_Numbers()
        {
            CheckEvaluation("12*30", 360);
        }

        [TestMethod]
        public void Can_Divide_Two_Integer_Numbers()
        {
            CheckEvaluation("30/5", 6);
        }

        [TestMethod]
        public void Multiple_Operations()
        {
            CheckEvaluation("2+3*5-8/2", 13);
        }

        [TestMethod]
        public void Two_Operations()
        {
            CheckEvaluation("2*3-5", 1);
        }

        [TestMethod]
        public void Multiple_Operand_And_Operators_Are_Parsed_Correctly()
        {
            var sut = new Parser(new OperatorFactory(), new OperandFactory());
            var result = sut.Parse("1+2*3-4").ToList();
            Assert.AreEqual(7, result.Count);
            Assert.IsInstanceOfType(result[0], typeof(Operand));
            Assert.IsInstanceOfType(result[1], typeof(Operator));
            Assert.IsInstanceOfType(result[2], typeof(Operand));
            Assert.IsInstanceOfType(result[3], typeof(Operator));
            Assert.IsInstanceOfType(result[4], typeof(Operand));
            Assert.IsInstanceOfType(result[5], typeof(Operator));
            Assert.IsInstanceOfType(result[6], typeof(Operand));
        }

        [TestMethod]
        public void First_Returns_First_Element()
        {
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var sut = new ElementList(new Element[] { lOperand, op, rOperand });
            var result = sut.First;
            Assert.AreEqual(lOperand, result);
        }

        [TestMethod]
        public void Two_Operations_Respecting_Precedence()
        {
            CheckEvaluation("2+3*5", 17);
        }

        [TestMethod]
        public void ComplexExpression()
        {
            CheckEvaluation("-2+3*(-5+8-9)/2", -11);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            CheckEvaluation("-3", -3);
        }
    }
}
