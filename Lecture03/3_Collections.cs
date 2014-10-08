using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture03
{
    public class Collections
    {
        public void Interfaces()
        {
            IEnumerable<int> ienumerable = new Stack<int>();
            ICollection<int> icollection = new Collection<int>();
            IList<int> ilist = new List<int>();
            ISet<int> iset = new HashSet<int>();

            var stack = new Stack<int>();
            var queue = new Queue<int>();
            var linkedList = new LinkedList<int>();
            
            var list = new List<int>();
            var readOnly = list as IReadOnlyList<int>;

            var hashSet = new HashSet<int>();
            var sortedSet = new SortedSet<int>();
        }
    }
}
