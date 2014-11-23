using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture07
{
    class ParallelLinq
    {
        static void MainPLinq(string[] args)
        {
            var numbers = Enumerable.Range(1, 1000000);

            var query = from n in numbers.AsParallel().AsOrdered()
                        where Enumerable.Range(2, (int) Math.Sqrt(n)).All(i => n%i > 0)
                        select n;

            TimeSpan time;

            var primes = Time(query.ToArray, out time);

            Console.WriteLine("Primes: {0}, first: {1}, last: {2}", time, primes.First(), primes.Last());
        }

        private static T Time<T>(Func<T> action, out TimeSpan time)
        {
            var stopwatch = Stopwatch.StartNew();

            var result = action();

            stopwatch.Stop();

            time = stopwatch.Elapsed;

            return result;
        }
    }
}
