using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Lecture01
{
    public static class Loops
    {
        public static void Reverse(object[] arr)
        {
            for (int s = 0, t = arr.Length - 1; s < t; s++, t--)
            {
                object tmp = arr[s];
                arr[s] = arr[t];
                arr[t] = tmp;
            }
        }

        public static object[] Reverse2(object[] arr)
        {
            return arr.Reverse().ToArray();
        }

        public static void ForEach(string[] lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public static void ForEachCoffee(string[] lines)
        {
            IEnumerator enm = lines.GetEnumerator();

            try
            {
                while (enm.MoveNext())
                {
                    var line = (string)enm.Current;
                    Console.WriteLine(line);
                }
            }
            finally
            {
                IDisposable disp = enm as IDisposable;
                if (disp != null)
                {
                    disp.Dispose();
                }
            }
        }

        public static void While(string path)
        {
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }

        public static void WhileCoffee(string path)
        {
            StreamReader reader = new StreamReader(path);

            try
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
            finally
            {
                reader.Close();
            }
        }

        private static readonly Random Rnd = new Random();

        public static int DoWhile()
        {
            int sum = 0, eyes;

            do
            {
                eyes = 1 + Rnd.Next(6);
                sum += eyes;
            } 
            while (eyes < 5);

            return sum;
        }
    }
}
