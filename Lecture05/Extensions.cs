using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture05
{
    public static class Extensions
    {
        public static IOrderedEnumerable<T> DoubleSort<T, TKey1, TKey2>(this IEnumerable<T> items, Func<T, TKey1> key1, Func<T, TKey2> key2)
        {
            return items.OrderBy(key1).ThenBy(key2);
        }

        public static IOrderedEnumerable<T> MultiSort<T>(this IEnumerable<T> items, params Func<T, dynamic>[] keys)
        {
            if (keys.Length == 0)
            {
                throw new ArgumentException("MultiSort requires at least one key", "keys");
            }

            var orders = items.OrderBy(keys[0]);

            if (keys.Length == 1)
            {
                return orders;
            }

            for (var i = 1; i < keys.Length; i++)
            {
                orders = orders.ThenBy(keys[i]);
            }

            return orders;
        }

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

        public static void Print<T>(this IEnumerable<T> items, string label)
        {
            Console.WriteLine(label + ":");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static void Print<TKey, TElement>(this IEnumerable<IGrouping<TKey, TElement>> groups)
        {
            foreach (var group in groups)
            {
                Console.WriteLine("Group Key: {0} (count: {1})", group.Key, group.Count());

                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
            }
        }
    }
}
