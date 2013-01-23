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

        #region Helper method

        public static void CheckEvaluation(string s, int expected)
        {
            var sut = new Evaluator();
            var result = sut.Eval(s);
            Assert.AreEqual(expected, result);
        }

        #endregion

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void String_Vazia_Ou_Nula_Deve_Retornar_Exception()
        {
            var sut = new Evaluator();
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
    }
}
