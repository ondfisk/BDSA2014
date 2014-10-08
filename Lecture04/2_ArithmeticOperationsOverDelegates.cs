using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    class ArithmeticOperationsOverDelegates
    {
        public delegate void Print();

        public static Print Printer { get; set; }

        static void _Main(string[] args)
        {
            Printer += PrintA;
            Printer += PrintB;
            Printer += PrintC;

            Printer();

            //Printer -= PrintB;

            //Printer();
        }

        public static void PrintA()
        {
            Console.WriteLine("A");
        }

        public static void PrintB()
        {
            Console.WriteLine("B");
        }

        public static void PrintC()
        {
            Console.WriteLine("C");
        }
    }
}
