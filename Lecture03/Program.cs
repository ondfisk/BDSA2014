using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture03
{
    class Program
    {
        static void Main(string[] args)
        {
            var strings = new[] { "xxx123", "aa12", "yy1", "1234" };


            foreach (var s in strings.OrderBy(s => s, new StringLengthComparer()))
            {
                Console.WriteLine(s);
            }
        }
    }
}
