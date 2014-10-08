using System;
using NUnit.Framework;

namespace PolishCalculator.Tests
{
    [TestFixture]
    public class StackCalculatorTests
    {
        [Test]
        public void Result_when_stack_is_empty_returns_0()
        {
            var calculator = new StackCalculator();

            var result = calculator.Result();

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Push_adds_Result_to_stack()
        {
            var calculator = new StackCalculator();

            calculator.Compute(42);

            var result = calculator.Result();

            Assert.AreEqual(42, result);
        }

        [Test]
        public void Push_twice_adds_values_to_stack()
        {
            var calculator = new StackCalculator();

            calculator.Compute(1);
            calculator.Compute(2);

            var expected = new[] {1, 2};

            var result = calculator.Stack;

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Stack_returns_clone()
        {
            var calculator = new StackCalculator();

            calculator.Compute(42);

            var clone = calculator.Stack;

            calculator.Compute(42);

            var current = calculator.Stack;

            CollectionAssert.AreNotEqual(clone, current);
        }

        [Test]
        public void Compute_20_22_Add_equals_42()
        {
            var calculator = new StackCalculator();

            calculator.Compute(20);
            calculator.Compute(22);
            calculator.Compute(BinaryOperation.Add);

            var result = calculator.Result();

            Assert.AreEqual(42, result);
        }

        [Test]
        public void Compute_BinaryOperation_when_stack_contains_0_elements_throws()
        {
            var calculator = new StackCalculator();

            Assert.Throws<InvalidOperationException>(() => calculator.Compute(BinaryOperation.Add));
        }

        [Test]
        public void Compute_BinaryOperation_when_stack_contains_1_element_throws()
        {
            var calculator = new StackCalculator();

            Assert.Throws<InvalidOperationException>(() => calculator.Compute(BinaryOperation.Add));
        }

        [Test]
        public void Compute_20_22_Add_stack_contains_42()
        {
            var calculator = new StackCalculator();

            calculator.Compute(20);
            calculator.Compute(22);
            calculator.Compute(BinaryOperation.Add);

            var result = calculator.Stack;

            var expected = new[] {42};

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_43_1_Subtract_stack_contains_42()
        {
            var calculator = new StackCalculator();

            calculator.Compute(43);
            calculator.Compute(1);
            calculator.Compute(BinaryOperation.Subtract);

            var result = calculator.Stack;

            var expected = new[] { 42 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_21_2_Multiply_stack_contains_42()
        {
            var calculator = new StackCalculator();

            calculator.Compute(21);
            calculator.Compute(2);
            calculator.Compute(BinaryOperation.Multiply);

            var result = calculator.Stack;

            var expected = new[] { 42 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_84_2_Divide_stack_contains_42()
        {
            var calculator = new StackCalculator();

            calculator.Compute(84);
            calculator.Compute(2);
            calculator.Compute(BinaryOperation.Divide);

            var result = calculator.Stack;

            var expected = new[] { 42 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_Divide_By_Zero_throws()
        {
            var calculator = new StackCalculator();

            calculator.Compute(42);
            calculator.Compute(0);

            Assert.Throws<DivideByZeroException>(() => calculator.Compute(BinaryOperation.Divide));
        }

        [Test]
        public void Compute_5_1_2_Add_4_Multiply_Add_3_Subtract_equals_14()
        {
            var calculator = new StackCalculator();

            calculator.Compute(5);
            calculator.Compute(1);
            calculator.Compute(2);
            calculator.Compute(BinaryOperation.Add);
            calculator.Compute(4);
            calculator.Compute(BinaryOperation.Multiply);
            calculator.Compute(BinaryOperation.Add);
            calculator.Compute(3);
            calculator.Compute(BinaryOperation.Subtract);

            var result = calculator.Stack;

            var expected = new[] { 14 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Result_when_stack_contains_more_than_1_element_throws()
        {
            var calculator = new StackCalculator();

            calculator.Compute(1);
            calculator.Compute(2);

            Assert.Throws<InvalidOperationException>(() => calculator.Result());
        }

        [Test]
        public void Compute_5_5_Add_equals_10()
        {
            var calculator = new StackCalculator();

            calculator.Compute(5);
            calculator.Compute(5);
            calculator.Compute(BinaryOperation.Add);

            var result = calculator.Stack;

            var expected = new[] { 10 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_5_5_2_Multiply_Add_equals_15()
        {
            var calculator = new StackCalculator();

            calculator.Compute(5);
            calculator.Compute(5);
            calculator.Compute(2);
            calculator.Compute(BinaryOperation.Multiply);
            calculator.Compute(BinaryOperation.Add);

            var result = calculator.Stack;

            var expected = new[] { 15 };

            CollectionAssert.AreEqual(expected, result);
        }
        
        [Test]
        public void Compute_1_2_Add_4_Multiply_5_Add_3_Subtract_equals_14()
        {
            var calculator = new StackCalculator();

            calculator.Compute(1);
            calculator.Compute(2);
            calculator.Compute(BinaryOperation.Add);
            calculator.Compute(4);
            calculator.Compute(BinaryOperation.Multiply);
            calculator.Compute(5);
            calculator.Compute(BinaryOperation.Add);
            calculator.Compute(3);
            calculator.Compute(BinaryOperation.Subtract);

            var result = calculator.Stack;

            var expected = new[] { 14 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_UnaryOperation_when_stack_contains_0_elements_throws()
        {
            var calculator = new StackCalculator();

            Assert.Throws<InvalidOperationException>(() => calculator.Compute(UnaryOperation.Increment));
        }

        [Test]
        public void Compute_41_Increment_equals_42()
        {
            var calculator = new StackCalculator();

            calculator.Compute(41);
            calculator.Compute(UnaryOperation.Increment);

            var result = calculator.Stack;

            var expected = new[] { 42 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_43_Decrement_equals_42()
        {
            var calculator = new StackCalculator();

            calculator.Compute(43);
            calculator.Compute(UnaryOperation.Decrement);

            var result = calculator.Stack;

            var expected = new[] { 42 };

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Compute_Invalid_BinaryOperation_throws()
        {
            var calculator = new StackCalculator();

            const BinaryOperation invalidBinaryOperation = (BinaryOperation) (-1);

            calculator.Compute(42);
            calculator.Compute(0);

            Assert.Throws<InvalidOperationException>(() => calculator.Compute(invalidBinaryOperation));
        }

        [Test]
        public void Compute_Invalid_UnaryOperation_throws()
        {
            var calculator = new StackCalculator();

            const UnaryOperation invalidUnaryOperation = (UnaryOperation)(-1);

            calculator.Compute(42);

            Assert.Throws<InvalidOperationException>(() => calculator.Compute(invalidUnaryOperation));
        }
    }
}
