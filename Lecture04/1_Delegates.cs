using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    public delegate int Compare(int a, int b);

    public class Delegates
    {
        private int number = 0; 

        public static int CrazyCompare(int z, int y)
        {
            return 0;
        }

        public void SortStuff()
        {
            var numbers = new[] { 1, 2, 3 };
            Sort(numbers, CrazyCompare);
        }
        

        public void Sort(int[] array, Compare compare)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    //if (compare.Invoke(array[j], array[j + 1]) > 0)
                    if (compare(array[j], array[j + 1]) > 0)
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public int Ascending(int a, int b)
        {
            return a.CompareTo(b);
        }

        public int Descending(int a, int b)
        {
            return b.CompareTo(a);
        }
    }

    class Program
    {
        static void _Main(string[] args)
        {
            var d = new Delegates();

            var array = new[] { 3, 4, 1, 2, 0 };

            Console.WriteLine("Start:");
            array.Print();

            d.Sort(array, new Compare(d.Ascending));

            Console.WriteLine();
            Console.WriteLine("Ascending:");
            array.Print();

            d.Sort(array, d.Descending);

            Console.WriteLine();
            Console.WriteLine("Descending:");
            array.Print();

            d.Sort(array, Random);

            Console.WriteLine();
            Console.WriteLine("Descending:");
            array.Print();

            #region Sugar
            return;
            Compare rnd = delegate(int a, int b)
            {
                return random.Next(-1, 2);
            };

            Compare rnd2 = (int a, int b) =>
            {
                return random.Next(-1, 2);
            };

            Compare rnd3 = (a, b) =>
            {
                return random.Next(-1, 2);
            };

            Compare rnd4 = (a, b) => random.Next(-1, 2);

            Compare rnd5 = (a, b) => random.Next(-1, 2);

            Func<int, int, int> rnd6 = (a, b) => random.Next(-1, 2);

            d.Sort(array, rnd4);

            d.Sort(array, (a, b) => random.Next(-1, 2));

            Console.WriteLine();
            Console.WriteLine("Random:");
            array.Print();
            #endregion
        }

        static Random random = new Random();

        static int Random(int a, int b)
        {
            return random.Next(-1, 2);
        }
    }
}
