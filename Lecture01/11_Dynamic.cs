using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture01
{
    public static class Dynamic
    {
        public static void M()
        {
            dynamic d1 = 31;
            int i1 = d1 * 2;    // cast (int)d1 at runtime
            bool b1 = d1;       // compiles ok, throws runtime exception

            dynamic p1 = new Contact("Beast", 666);
            string name = p1.Name;      // property access checked at runtime
            int n2 = p1.Age;            // compiles ok, throws runtime exception
        }
    }

    internal class Contact
    {
        public string Name { get; private set; }
        public int Phone { get; private set; }

        public Contact(string name, int phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
