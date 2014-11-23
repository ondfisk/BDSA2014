using System;
using System.Threading;

namespace Lecture07
{
    class Threads1
    {
        /// <summary>
        /// Run an open Process Explorer...
        /// </summary>
        /// <param name="args"></param>
        private static void MainOld(string[] args)
        {
            Console.WriteLine("Hello Threads");
            Console.ReadKey();
        }


        /// <summary>
        /// Run an open Process Explorer...
        /// </summary>
        /// <param name="args"></param>
        private static void MainMany(string[] args)
        {
            Console.WriteLine("Hello Threads");
            var t = new Thread[1000];
            for (var i = 0; i < t.Length; i++)
            {
                var number = i + 1;
                t[i] = new Thread(() =>
                {
                    Console.WriteLine("I'm thread no. {0}", number);
                    Thread.Sleep(100000);
                });
                t[i].Start();
            }
            Console.ReadKey();
        }
    }
}
