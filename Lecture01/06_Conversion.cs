using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture01
{
    public static class Conversion
    {
        static void NumericConversion()
        {
            int i = 42;
            double d = i;
            Console.WriteLine(i / 5);
            Console.WriteLine(d / 5);
            Console.WriteLine(i / 5.0);

            //int willFail = 42.0;
            //int willAlsoFail = i / 1.0;

            int i2 = (int)42.0;
            int i3 = (int)(i / 1.0);
            int i4 = Convert.ToInt32(42.0);
        }
    }
}
