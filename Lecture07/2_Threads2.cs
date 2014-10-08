using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture07
{
    class Threads2
    {

        /// <summary>
        /// Run multiple times - compare output
        /// </summary>
        /// <param name="args"></param>
        private static void Main2(string[] args)
        {
            var t = new Thread(WriteX);
            t.Start();

            for (var i = 0; i < 40; i++)
            {
                Console.Write('Y');
            }
        }

        private static void WriteX()
        {
            for (var i = 0; i < 40; i++)
            {
                Console.Write('X');
            }
        }
    }
}
