using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture07
{
    class TaskParallelLibrary2
    {
        static void MainTPL(string[] args)
        {
            //Parallel.For()
            //Parallel.ForEach()
            //Parallel.Invoke();

            //for (int i = 0; i < 1000; i++)
            //Parallel.For(0, 1000, i =>
            //{
            //    Console.WriteLine(i);
            //});

            //List<int> numbers = Enumerable.Range(0, 1000000).ToList();

            //Parallel.ForEach(numbers, Console.WriteLine);

            var sw = Stopwatch.StartNew();

            Parallel.Invoke(SuperLongRunningThingy1, SuperLongRunningThingy2, SuperLongRunningThingy3, SuperLongRunningThingy4,
                SuperLongRunningThingy1, SuperLongRunningThingy2, SuperLongRunningThingy3, SuperLongRunningThingy4,
                SuperLongRunningThingy1, SuperLongRunningThingy2, SuperLongRunningThingy3, SuperLongRunningThingy4);

            sw.Stop();
            sw.Start();

            Console.WriteLine(sw.Elapsed);
        }

        private static void SuperLongRunningThingy1()
        {
            Thread.Sleep(2000);
        }
        private static void SuperLongRunningThingy2()
        {
            Thread.Sleep(2000);
        }
        private static void SuperLongRunningThingy3()
        {
            Thread.Sleep(2000);
        }
        private static void SuperLongRunningThingy4()
        {
            Thread.Sleep(2000);
        }
    }
}
