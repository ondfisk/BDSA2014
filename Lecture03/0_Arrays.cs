using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture03
{
    public class Arrays
    {
        public void OneDimentionalArrays<T>(int arraySize)
        {
            T[] arrayName = new T[arraySize];

            float[] values = new float[15];
            Console.WriteLine(values[5]);
            Console.WriteLine(values[15]); // What happens here?
        }

        public void ArrayInitialization()
        {
            // Laborious Array Initialization
            var workingWeekDayNames0 = new string[5];
            workingWeekDayNames0[0] = "Monday";
            workingWeekDayNames0[1] = "Tuesday";
            workingWeekDayNames0[2] = "Wednesday";
            workingWeekDayNames0[3] = "Thursday";
            workingWeekDayNames0[4] = "Friday";

            // Array Initializer Syntax
            var workingWeekDayNames1 = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            // Shorter Array Initializer Syntax
            string[] workingWeekDayNames2 = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            // Initializer Syntax With Element Type Inference
            var workingWeekDayNames3 = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        }

        public void MultidimensionalRectangularArrays<T>(int xSize, int ySize, int zSize)
        {
            T[, ,] arrayName = new T[xSize, ySize, zSize];

            double[,] matrixA = new double[10, 20];
            var matrixB = new double[10, 20];

            string[,] data = { { "Test", "Data" }, 
                               { "Hello", "World" } };

            int[,] gameMap = { { 0, 1, 1, 1, 0 }, 
                               { 0, 1, 1, 0, 1 },  
                               { 1, 0, 0, 1, 0 } };

            if (gameMap[2, 2] == 1)
            {
                // ...
            }
        }

        public void JaggedArrays()
        {
            int[][] jaggedArray0 = new int[5][];

            int[,][] jaggedArray1 = new int[5, 6][];

            // int [,][] jaggedArray2 = new int[5,6][6];

            int[][] jaggedArray3 = new int[5][];
            for (int i = 0; i < jaggedArray3.Length; i++)
            {
                jaggedArray3[i] = new int[6];
            }
            //int[,] jaggedArray3 = new int[5,6];

            int[][] jaggedArray4 = new int[5][];

            for (int i = 0; i < jaggedArray4.Length; i++)
            {
                if (i % 2 == 0)
                {
                    jaggedArray4[i] = new int[6];
                }
                else
                {
                    jaggedArray4[i] = new int[10];
                }
            }
        }

        public void PropertiesOfArrays()
        {
            int[] array = { 1, 0, 0 };

            int len = array.Length; // len = 3

            int dim = array.Rank; // dim = 1
        }

        public void PropertiesOfMultidimensionalArrays()
        {
            int[,] array = { { 1, 0, 0 }, 
                             { 0, 1, 0 }, 
                             { 0, 0, 1 } };

            int len = array.Length; // len = ??

            int dim = array.Rank; // dim = ?

            int len0 = array.GetLength(0); // len0 = ??
            int len1 = array.GetLength(1); // len1 = ??

            Console.WriteLine("Length: {0}", len);
            Console.WriteLine("Rank: {0}", dim);
            Console.WriteLine("Len0: {0}", len0);
            Console.WriteLine("Len1: {0}", len1);
        }

        public void ArrayClassMethods() // Works only on single dimention arrays
        {
            int[] array = { 3, 4, 1, 5, 2 };

            Array.Reverse(array); // array = { 2, 5, 1, 4, 3 }

            Array.Sort(array); // array = { 1, 2, 3, 4, 5 }

            // Binary Search - Array must be ??
            int pos = Array.BinarySearch(array, 2); // pos = 1

            if (pos >= 0)
            {
                Console.WriteLine("Found in position {0}", pos);
            }
            else
            {
                Console.WriteLine("Not Found! Belongs in position: {0}", ~pos);
            }
        }

        public void Fail()
        {
            int[,] array = { { 1, 0, 0 }, 
                             { 0, 1, 0 }, 
                             { 0, 0, 1 } };

            Array.Sort(array);
        }
    }
}
