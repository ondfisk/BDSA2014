using System;
using System.Collections.Generic;

namespace PolishCalculator
{
    public class StackCalculator
    {
        private readonly Stack<int> _stack;

        /// <summary>
        /// Returns a clone of the Stack
        /// </summary>
        public Stack<int> Stack
        {
            get { return new Stack<int>(_stack); }
        }

        public StackCalculator()
        {
            _stack = new Stack<int>();
        }

        public int Result()
        {
            var count = _stack.Count;

            switch (count)
            {
                case 0:
                    return 0;
                case 1:
                    return _stack.Peek();
                default:
                    throw new InvalidOperationException("Stack contains more than one value");
            }
        }

        public void Compute(int value)
        {
            _stack.Push(value);
        }

        public void Compute(BinaryOperation operation)
        {
            var right = _stack.Pop();
            var left = _stack.Pop();

            switch (operation)
            {
                case BinaryOperation.Add:
                    _stack.Push(left + right);
                    break;
                case BinaryOperation.Subtract:
                    _stack.Push(left - right);
                    break;
                case BinaryOperation.Multiply:
                    _stack.Push(left * right);
                    break;
                case BinaryOperation.Divide:
                    _stack.Push(left / right);
                    break;
                default:
                    throw new InvalidOperationException("Unknown binary operation");
            }
        }

        public void Compute(UnaryOperation operation)
        {
            var x = _stack.Pop();

            switch (operation)
            {
                case UnaryOperation.Increment:
                    _stack.Push(x + 1);
                    break;
                case UnaryOperation.Decrement:
                    _stack.Push(x - 1);
                    break;
                default:
                    throw new InvalidOperationException("Unknown unary operation");
            }
        }
    }
}
