using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture01
{
    public static class LocalVariableTypeInference
    {
        //var field = "Blue";

        public static void M()
        {
            var person = new {Age = 325, Name = "Methusalem"};
            var person2 = new {Age = 325, Name = "Methusalem", PostalCode = 2100};
            var person3 = new {Age = 325, Name = "Methusalem", Surname = "Totally not known"};

            var age = 25;       // inferred type int
            var flag = false;   // inferred type bool

            var dict = new Dictionary<int, string>();

            object[] objects = {3, "Hello", 5.6};
            foreach (var val in objects)
            {
                Console.WriteLine(val);
            }
        }
    }
}
