using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture03
{
    public class Strings
    {
        public void Hello()
        {
            string str = "Hello!";

            int len = str.Length; // len = 6

            char ch = str[0]; // ch = 'H'
        }

        public void Split()
        {
            string csv0 = "Dario,Anna,Mark,Jen,Joe";
            string[] names0 = csv0.Split(',');

            // names0 = { "Dario", "Anna", "Mark", "Jen", "Joe" }

            string csv1 = "Dario:Anna;Mark,Jen.Joe";
            string[] names1 = csv0.Split(',', ':', ';', '.');

            string csv2 = "Dario,Anna,,Mark,Jen,Joe";
            string[] names2 = csv0.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public void Verbatim()
        {
            string str1 = "Hello";
            string str2 = "\u0048ello";
            string str3 = @"\u0048ello";

            Console.WriteLine(str1); // Hello
            Console.WriteLine(str2); // Hello
            Console.WriteLine(str3); // \u0048ello
        }

        public void Empty()
        {
            var empty0 = "";
            var empty1 = string.Empty;

            if (string.IsNullOrEmpty(empty0))
            {
                // do stuff
            }

            var whiteSpace = "    ";

            if (string.IsNullOrWhiteSpace(whiteSpace))
            {
                // do stuff
            }
        }

        public void Format()
        {
            //string.Format()

            DateTime time = DateTime.Now;
            string message = "Gas bill";
            decimal amount = 600m;
            string format = "{0} {1} {2}";

            string text = string.Format(format, time, message, amount);
  
            // Options: c, n2, d, yyyy-MM...

            // http://msdn.microsoft.com/en-us/library/26etazsy(v=vs.110).aspx
        }

        public void FormatCulture()
        {
            Console.WriteLine("Paid, {0:c}", 300);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            Console.WriteLine("Paid, {0:c}", 300);
        }

        public void Concat()
        {
            var t1 = "Hitchhiker's Guide";
            var t2 = " to the Galaxy";

            var title = t1 + t2;

            var title2 = string.Concat(t1, t2);
        }

        public void Join()
        {
            var lines = new[] { 
                "Life betrayal - a warping rage",
                "Evil ripping caverns through your mind",
                "Immolation - in blood you've signed your soul away",
                "Sickening life ends but the horror has just begun",
                "Vultures moaning a funeral dirge",
                "Walls await to cradle you and rip your soul apart",
                "Incessant screams echoes through the maze"
            };

            var verse = string.Join(Environment.NewLine, lines);

            Console.WriteLine(verse);
        }
    }
}
