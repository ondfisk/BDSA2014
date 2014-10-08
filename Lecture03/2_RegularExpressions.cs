using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lecture03
{
    public class RegularExpressions
    {
        public void Groups()
        {
            string text = @"http://www.test.com ftp://ftp.test.com";
                                                            // ?: = Non-capturing group
            MatchCollection matches = Regex.Matches(text, @"\b(?:\S+)://(\S+)\b");

            foreach (Match match in matches)
            {
                foreach (Group group in match.Groups)
                {
                    Console.WriteLine("{0}: {1}", match.Index, group);
                }
            }
        }
    }
}
