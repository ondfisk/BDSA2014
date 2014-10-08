using System;

namespace Lecture01
{
    public static class Equality
    {
        public static void MainEq(string[] args)
        {
            var p1 = new Person("Joe");
            var p2 = new Person("Joe");
            var p3 = p2;
           
            Console.WriteLine("ReferenceEquals(p1, p2): {0}", object.ReferenceEquals(p1, p2));
            Console.WriteLine("ReferenceEquals(p2, p3): {0}", object.ReferenceEquals(p2, p3));

            Console.WriteLine("Equals(p1, p2): {0}", object.Equals(p1, p2));
            Console.WriteLine("Equals(p2, p3): {0}", object.Equals(p2, p3));
            Console.WriteLine("p1.Equals(p2): {0}", p1.Equals(p2));
            Console.WriteLine("p2.Equals(p3): {0}", p2.Equals(p3));
            Console.WriteLine("p1 == p2: {0}", p1 == p2);
            Console.WriteLine("p2 == p3: {0}", p2 == p3);

            //StringEquality();
        }

        public static void StringEquality()
        {
            string a = "Joe";
            string b = "Joe";

            Console.WriteLine("Equals(a, b): {0}", Equals(a, b));
            
            Console.WriteLine("a == b: {0}", a == b);

            Console.WriteLine("ReferenceEquals(a, b): {0}", ReferenceEquals(a, b));

            Console.WriteLine("ReferenceEquals(a, \"Joe\"): {0}", ReferenceEquals(a, "Joe"));
        }
    }

    public class Person
    {
        private readonly string _name;

        public string Name { get { return _name; } }

        public Person(string name)
        {
            _name = name;
        }

        //public override bool Equals(object obj)
        //{
        //    var other = obj as Person;

        //    if (other == null)
        //    {
        //        return false;
        //    }

        //    return Name == other.Name;
        //}

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}

        //public static bool operator ==(Person a, Person b)
        //{
        //    return Equals(a, b);
        //}

        //public static bool operator !=(Person a, Person b)
        //{
        //    return !Equals(a, b);
        //}
    }

    public struct PersonValueType
    {
        private readonly string _name;

        public string Name { get { return _name; } }

        public PersonValueType(string name)
        {
            _name = name;
        }

        //public static bool operator ==(PersonValueType a, PersonValueType b)
        //{
        //    return a.Name == b.Name;
        //}

        //public static bool operator !=(PersonValueType a, PersonValueType b)
        //{
        //    return a.Name != b.Name;
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj is PersonValueType)
        //    {
        //        return this == (PersonValueType)obj;
        //    }

        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}
    }
}
