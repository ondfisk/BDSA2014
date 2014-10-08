using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture03
{
    public class Lists
    {
        public void Initializers()
        {
            List<int> list = new List<int>();
            list.Add(3);
            list.Add(5);
            list.Add(6);
            Console.WriteLine(list[2]); // writes 6

            list = new List<int> {3, 4, 6};
        }

        public void Constructors()
        {
            var basic = new List<int>();

            var initializer = new List<int> { 1, 2, 3 };

            var capacity = new List<int>(42);

            var fromOther = new List<int>(initializer);
        }

        public void Iterator()
        {
            var contacts = new List<Contact> 
            {
                new Contact { Name = "The Beast", Number = 666 },
                new Contact { Name = "The neighbor of the Beast", Number = 668 }
            };

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        struct Contact
        {
            public string Name { get; set; }
            public int Number { get; set; }

            public override string ToString()
            {
                return string.Format("{0}: {1}", Name, Number);
            }
        }

        public void Methods()
        {
            var list = new List<int> { 3, 1, 2, 5, 4 };

            list.Reverse();

            list.Sort();

            // Collection MUST be sorted
            int pos = list.BinarySearch(4); // pos = 3 
        }
    }
}
