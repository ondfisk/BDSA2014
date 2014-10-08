using System;
using System.Collections.Generic;

namespace Lecture01
{
    public static class Variables
    {
        public static void Var()
        {
            int x, y, z;
            x = 1;
            y = 2;
            z = 3;

            int i = 42;

            double d = 1.0;

            string hello = "Hello World";

            Dictionary<string, object[]> dict = new Dictionary<string, object[]>();

            int j = 3, k = 4, l = 5;

            k = l = 7;
        }
    }

    public enum Day { Mon, Tue, Wed, Thu, Fri, Sat, Sun }

    public enum Month : uint { Jan = 1, Feb, Mar, }

}
