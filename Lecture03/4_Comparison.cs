using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture03
{
    public class Comparable : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

    public class ComparableOfT : IComparable<ComparableOfT>
    {
        public int CompareTo(ComparableOfT other)
        {
            throw new NotImplementedException();
        }
    }

    public class Comparable<T> : IComparable<T>
    {
        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }
    }

    public class Equatable
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class EquatableOfT : IEquatable<EquatableOfT>
    {
        public bool Equals(EquatableOfT other)
        {
            throw new NotImplementedException();
        }
    }

    public class Equatable<T> : IEquatable<T>
    {
        public bool Equals(T other)
        {
            throw new NotImplementedException();
        }
    }

    public class StringLengthComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length < y.Length)
            {
                return -1;
            }
            else if (x.Length > y.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class FirstLetterEquals : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(x.Substring(0, 1), y.Substring(0, 1), StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            return char.ToLower(obj[0]).GetHashCode();
        }
    }
}
