using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture07
{
    class Threads3
    {
        private static void Write(char c, int count)
        {
            for (var i = 0; i < count; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
        
        private static void WriteX()
        {
            Write('X', 40);
        }

        private static void Write(object c)
        {
            Write((char) c, 40);
        }

        private static void Main3(string[] args)
        {
            var t1 = new Thread(WriteX);
            t1.Start();

            var t2 = new Thread(Write);
            t2.Start('Z');

            var t3 = new Thread(() => Write('Y', 40));
            t3.Start();
        }
    }
}
