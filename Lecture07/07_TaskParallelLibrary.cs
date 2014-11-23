using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture07
{
    class TaskParallelLibrary1
    {
        static void Race(StringBuilder sb, string name, int count)
        {
            for (var i = 0; i < count; i++)
            {
                sb.AppendFormat("{0}: {1}\r\n", name, i);
            }
        }

        static void MainTPL(string[] args)
        {
            ResultCancelled();
        }

        static void TaskFactory()
        {
            var sb = new StringBuilder();
            var t1 = Task.Factory.StartNew(() => Race(sb, "One", 50));
            var t2 = Task.Run(() => Race(sb, "Two", 50));

            Console.WriteLine(sb);
        }

        static void Wait()
        {
            var sb = new StringBuilder();
            var t1 = Task.Factory.StartNew(() => Race(sb, "One", 50));
            var t2 = Task.Run(() => Race(sb, "Two", 50));

            t1.Wait();
            t2.Wait();

            Console.WriteLine(sb);
        }

        static void WaitAll()
        {
            var sb = new StringBuilder();
            var t1 = Task.Factory.StartNew(() => Race(sb, "One", 50));
            var t2 = Task.Run(() => Race(sb, "Two", 50));

            Task.WaitAll(t1, t2);

            Console.WriteLine(sb);
        }

        static void Attached()
        {
            var sb = new StringBuilder();

            var t = Task.Run(() =>
            {
                Task.Factory.StartNew(() => Race(sb, "One", 50), TaskCreationOptions.AttachedToParent);
                Task.Factory.StartNew(() => Race(sb, "Two", 50), TaskCreationOptions.AttachedToParent);
            });
            t.Wait();

            Console.WriteLine(sb);
        }

        static void Continuation()
        {
            var sb = new StringBuilder();

            var t1 = Task.Run(() => Race(sb, "One", 5))
                         .ContinueWith(t2 => Race(sb, "Two", 5))
                         .ContinueWith(t3 => Race(sb, "Three", 5));

            t1.Wait();

            Console.WriteLine(sb);
        }

        private static void Result()
        {
            Task<int> t = Task.Run(() =>
            {
                Thread.Sleep(2000);
                var factorial = 1;
                for (var i = 2; i <= 6; i++)
                {
                    factorial *= i;
                }
                return factorial;
            });

            Console.WriteLine("Task started");
            Console.WriteLine(t.Result); // <= Blocking! Waits for task to finish
        }

        private static void Cancellation()
        {
            var sb = new StringBuilder();
            var tokenSource = new CancellationTokenSource();

            var t1 = Task.Factory.StartNew(() => Race(sb, "One", 50, tokenSource.Token));
            var t2 = Task.Run(() => Race(sb, "Two", 50, tokenSource.Token));

            Thread.Sleep(20);
            tokenSource.Cancel();

            Task.WaitAll(t1, t2);

            Console.WriteLine(sb);
        }

        static void Race(StringBuilder sb, string name, int count, CancellationToken token)
        {
            for (var i = 0; i < count && !token.IsCancellationRequested; i++)
            {
                lock (sb)
                {
                    sb.AppendFormat("{0}: {1}\r\n", name, i);
                }
                Thread.Sleep(2);
            }
        }

        static void ResultCancelled()
        {
            var tokenSource = new CancellationTokenSource();

            var t = Task.Run(() =>
            {
                Thread.Sleep(2000);
                var factorial = 1;
                for (var i = 2; i <= 6; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }, tokenSource.Token);

            tokenSource.Cancel();

            Console.WriteLine("Task started");
            Console.WriteLine(t.Result); // <= Blocking! Waits for task to finish
        }
    }
}
