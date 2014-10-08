using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntList = System.Collections.Generic.List<int>;

namespace Lecture04
{
    public class P
    {
        static void Main()
        {
            var iis = new IntList();
            

            var articles = new[] {
                new Article42 { Title = "42" },
                new Article42 { Title = "43" },
                new Article42 { Title = "44" },
                new Article42 { Title = "46" },
            };

            articles.Print();
        }
    }

    public interface ITitle
    {
        string Title { get; }
    }

    public static class Extensions
    {
        public static void Print(this IEnumerable<int> array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        public static void Print<T>(this IEnumerable<T> array) where T : ITitle
        {
            var titles = array.Select(t => t.Title);

            Console.WriteLine(string.Join(", ", titles));
        }
    }

    public class Article42 : ITitle
    {

        public string Title
        {
            get;
            set;
        }

        public int Id { get; set; }
    }
}
