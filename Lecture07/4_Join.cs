using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture07
{
    class Join
    {
        private static void MainJoin(string[] args)
        {
            var t1 = new Thread(
                () =>
                {
                    for (var i = 0; i < 5; i++)
                    {
                        Console.WriteLine("Hello");
                    }
                });

            t1.Start();
            t1.Join();
            Console.WriteLine("Thread t has ended");
            Thread.Sleep(3000);
            Console.WriteLine("Done waiting...");
        }
    }
}
