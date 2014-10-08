using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture03
{
    public class Dictionaries
    {
        public void Types()
        {
            var keyValuePair = new KeyValuePair<int, string>();

            IDictionary<int, string> dictionary = new Dictionary<int, string>();

            IDictionary<int, string> sorted = new SortedDictionary<int, string>();
        }

        public void Constructors()
        {
            var initializer = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
            };

            IDictionary<string, Area> map = new Dictionary<string, Area>(new MyEqualityComparer());

            IDictionary<string, Area> sorted = new SortedDictionary<string, Area>(new MyComparer());
        }

        public void Methods()
        {
            var dictionary = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
            };
            dictionary.Add(5, "Five");
            dictionary.Remove(4);

            var has1 = dictionary.ContainsKey(1); // O(1)
            var hasOne = dictionary.ContainsValue("One"); // O(n) !!

            var one = dictionary[1]; // Throws if key not found

            dictionary[666] = "Six hundred three score and six";

            string value;
            if (dictionary.TryGetValue(666, out value))
            { 
                // Found the beast...
            }
        }

        public class MyEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                throw new NotImplementedException();
            }

            public int GetHashCode(string obj)
            {
                throw new NotImplementedException();
            }
        }

        public class MyComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                throw new NotImplementedException();
            }
        }

        public class Area
        {
        }
    }
}
