using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecture06
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);

                var enumerable = item as System.Collections.IEnumerable;

                if (enumerable != null)
                {
                    Console.WriteLine("Values: {0}", string.Join(", ", enumerable.Cast<object>().ToArray()));
                }
            }
        }
    }
}
