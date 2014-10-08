using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture07
{
    class RaceCondition
    {
        static void Race(StringBuilder sb, string name, int count)
        {
            for (var i = 0; i < count; i++)
            {
                sb.AppendFormat("{0}: {1}\r\n", name, i);
            }
        }

        static void MainRace(string[] args)
        {
            var sb = new StringBuilder();
            var t1 = new Thread(() => Race(sb, "One", 50));
            var t2 = new Thread(() => Race(sb, "Two", 50));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(sb);
        }
    }

    class FixedRace
    {
        static void Race(StringBuilder sb, string name, int count)
        {
            for (var i = 0; i < count; i++)
            {
                lock (sb)
                {
                    sb.AppendFormat("{0}: {1}\r\n", name, i);
                }
            }
        }

        static void MainFix(string[] args)
        {
            var sb = new StringBuilder();
            var t1 = new Thread(() => Race(sb, "One", 50));
            var t2 = new Thread(() => Race(sb, "Two", 50));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(sb);
        }
    }

    class BehindTheScenes
    {
        static void Race(StringBuilder sb, string name, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var lockAquired = false;
                try
                {
                    Monitor.Enter(sb, ref lockAquired);
                    sb.AppendFormat("{0}: {1}\r\n", name, i);
                }
                finally
                {
                    if (lockAquired)
                    { 
                        Monitor.Exit(sb);
                    }
                }
            }
        }

        static void MainBTS(string[] args)
        {
            var sb = new StringBuilder();
            var t1 = new Thread(() => Race(sb, "One", 50));
            var t2 = new Thread(() => Race(sb, "Two", 50));
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(sb);
        }
    }
}
