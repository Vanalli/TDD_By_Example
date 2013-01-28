using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math.ExpressionEvaluator.Tests
{
    [TestClass]
    public class ElementListTests
    {
        [TestMethod]
        public void Find_Operation_Returns_First_Operation()
        {
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var sut = new ElementList(new Element[] { new Operand(0), new Operand(0), lOperand, op, rOperand });
            var result = sut.FindOperation();
            Assert.AreEqual(lOperand, result.LOperand);
            Assert.AreEqual(op, result.Op);
            Assert.AreEqual(rOperand, result.ROperand);
        }

        [TestMethod]
        //[Ignore]
        public void Replace_Operation_Replaces_The_Correct_One()
        {
            var otherOpd1 = new Operand(0);
            var otherOp = new AddOperator();
            var otherOpd2 = new Operand(0);
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var sut = new ElementList(new Element[] { otherOpd1, otherOp, otherOpd2, lOperand, op, rOperand });
            var operation = new Operation(lOperand, op, rOperand);
            sut.ReplaceOperation(operation, new Operand(0));

            var result = sut.FindOperation();
            Assert.AreEqual(otherOpd1, result.LOperand);
            Assert.AreEqual(otherOp, result.Op);
            Assert.AreEqual(otherOpd2, result.ROperand);
        }

        [TestMethod]
        public void Replace_Operation_Works()
        {
            var lOperand = new Operand(0);
            var op = new AddOperator();
            var rOperand = new Operand(0);
            var sut = new ElementList(new Element[] { lOperand, op, rOperand });
            var operation = new Operation(lOperand, op, rOperand);
            sut.ReplaceOperation(operation, new Operand(0));

            var result = sut.FindOperation();
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Find_Operation_Returns_Highest_Precedence()
        {
            var lOperand = new Operand(0);
            var op = new MulOperator();
            var rOperand = new Operand(0);
            var sut = new ElementList(new Element[] { new Operand(0), new AddOperator(), new Operand(0), lOperand, op, rOperand });
            var result = sut.FindOperation();
            Assert.AreEqual(lOperand, result.LOperand);
            Assert.AreEqual(op, result.Op);
            Assert.AreEqual(rOperand, result.ROperand);
        }
    }
}
