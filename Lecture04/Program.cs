using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture04
{
    public class Program2
    {
        private Action<string> _logger;

        public Program2(Action<string> logger)
        {
            _logger = logger ?? Console.WriteLine;
        }

        public void DoStuff()
        { 
            //........
            _logger("done stuff");
        }

        public static void _Main(string[] args)
        {
            Func<int, bool> evenFunc = x => x % 2 != 0;

            var list = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> evens = list.Where(evenFunc);

            Action<string> print = s => { };

            evens.Print();

            var desc = evens.OrderByDescending(i => i);

            desc.Print();
        }
    }
}
