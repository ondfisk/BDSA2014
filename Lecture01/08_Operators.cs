using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture01
{
    static class Program
    {
        static void Main(string[] args)
        {
            //NumericConversion();

            //IntegerOverflow();

            //Fibonacci();

            FibonacciRecursive(0, 1, 0);

            //CheckedFibonacci();

            //BasicArithmeticOperators();

            //RelationalOperators();

            //BooleanOperators();

            //BitwiseOperators();

            //CompoundAssignmentOperators();

            Console.ReadLine();
        }

        static void BasicArithmeticOperators()
        {
            int x = 7;
            int y = 6;

            int identity = +x;
            int negation = -x;
            int postIncrement = x++;
            int postDecrement = x--;
            int preIncrement = ++x;
            int preDecrement = --x;
            int multiplication = x * y;
            int division = x / y;
            int remainder = x % y;
            int addition = x + y;
            int subtraction = x - y;
        }

        static void RelationalOperators()
        {
            int x = 7;
            int y = 6;

            bool lessThan = x < y;
            bool greaterThan = x > y;
            bool lessThanOrEqual = x <= y;
            bool greaterThanOrEqual = x <= y;
            bool equal = x == y;
            bool notEqual = x != y;
        }

        static void BooleanOperators()
        {
            bool t = true;
            bool f = false;

            bool not = !t;
            bool eq = t == f;
            bool ne = t != f;
            bool or = t || f;
            bool and = t && f;
            bool xor = t ^ f;
        }

        static void BitwiseOperators()
        {
            int x = 127;
            int y = 116;

            Console.WriteLine("x = {0}", x);
            Console.WriteLine("y = {0}", y);
            Console.WriteLine();

            Console.WriteLine("Bitwise negation:");
            Console.WriteLine("x:      {0}", x.ToBinary());
            Console.WriteLine("~x      {0}", (~x).ToBinary());
            Console.WriteLine();

            Console.WriteLine("Bitwise AND:");
            Console.WriteLine("x:      {0}", x.ToBinary());
            Console.WriteLine("y:      {0}", y.ToBinary());
            Console.WriteLine("x&y:    {0}", (x & y).ToBinary());
            Console.WriteLine();

            Console.WriteLine("Bitwise OR:");
            Console.WriteLine("x:      {0}", x.ToBinary());
            Console.WriteLine("y:      {0}", y.ToBinary());
            Console.WriteLine("x|y:    {0}", (x | y).ToBinary());
            Console.WriteLine();

            Console.WriteLine("Bitwise XOR:");
            Console.WriteLine("x:      {0}", x.ToBinary());
            Console.WriteLine("y:      {0}", y.ToBinary());
            Console.WriteLine("x^y:    {0}", (x ^ y).ToBinary());
            Console.WriteLine();

            Console.WriteLine("Shift left by 1:");
            Console.WriteLine("x:      {0}", x.ToBinary());
            Console.WriteLine("x << 1: {0}", (x << 1).ToBinary());
            Console.WriteLine();

            Console.WriteLine("Shift right by 2:");
            Console.WriteLine("x:      {0}", x.ToBinary());
            Console.WriteLine("x >> 2: {0}", (x >> 2).ToBinary());
            Console.WriteLine();

            // The Power of 2...
            for (int i = 1; i > 0; i = i << 1)
            {
                Console.WriteLine(i);
            }
        }

        static string ToBinary(this int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }

        static void CompoundAssignmentOperators()
        {
            var x = 42;

            x -= 42; // x = x - 42;
            Console.WriteLine(x);

            x += 42; // x = x + 42
            Console.WriteLine(x);

            x /= 6; // x = x / 6;
            Console.WriteLine(x);

            x *= 6; // x = x * 6;
            Console.WriteLine(x);

            x %= 5; // x = x % 5;
            Console.WriteLine(x);

            x = 42;

            Console.WriteLine(x.ToBinary());

            x >>= 1; // x = x >> 1;
            Console.WriteLine(x.ToBinary());

            x <<= 1; // x = x << 1;
            Console.WriteLine(x.ToBinary());

            x |= 7;
            Console.WriteLine(x.ToBinary());

            x &= 7;
            Console.WriteLine(x.ToBinary());

            x ^= 7;
            Console.WriteLine(x.ToBinary());
        }

        static void NumericConversion()
        {
            int i = 42;
            double d = i;
            Console.WriteLine(i / 5);
            Console.WriteLine(d / 5);
            Console.WriteLine(i / 5.0);

            //int willFail = 42.0;
            //int willAlsoFail = i / 1.0;

            int i2 = (int)42.0;
            int i3 = (int)(i / 1.0);
            int i4 = Convert.ToInt32(42.0);
        }

        static void IntegerOverflow()
        {
            int max = int.MaxValue;
            int maxPlusOne = max + 1;

            Console.WriteLine("Max: {0}", max);
            Console.WriteLine("Max+1: {0}", maxPlusOne);

            //int checkedMaxPlusOne = checked(max + 1);

            checked
            {
                int checkedMaxPlusOne = checked(max + 1);
            }
        }

        static void Fibonacci()
        {
            //int i1 = 1;
            //int i2 = i1;

            //long i1 = 1;
            //long i2 = i1;

            // double - increase c to 1500
            //double i1 = 1;
            //double i2 = i1;

            // BigInteger - increase c to 2500
            BigInteger i1 = 1;
            BigInteger i2 = i1;

            Console.WriteLine(i1);

            for (var c = 0; c <= 250; c++)
            {
                Console.WriteLine(c + ": " + i2);

                var i3 = i1 + i2;
                i1 = i2;
                i2 = i3;
            }
        }

        private static void CheckedFibonacci()
        {
            int i1 = 1;
            int i2 = i1;

            Console.WriteLine(i1);

            for (var c = 0; ; c++)
            {
                Console.WriteLine(c + ": " + i2);

                int i3;
            
                try
                {
                    i3 = checked(i1 + i2);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow...");
                    break;
                }

                i1 = i2;
                i2 = i3;
            }
        }

        static int FibonacciRecursive(int i1, int i2, int count)
        {
            Console.WriteLine("{0}: {1}", count, i2);

            int i3 = i1 + i2;
            
            return FibonacciRecursive(i2, i3, ++count);
        }
    }
}
