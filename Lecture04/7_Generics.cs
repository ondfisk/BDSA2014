using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture04
{
    class Run
    {
        static void __Main()
        { 
            var g = new Generics<int>(42);

            g.Nullify();
        }

        static void Scramble<T>(List<T> stuff)
        { 
        
        }
    }

    class Generics<T> where T : new()
    {
        T inner;

        public Generics()
        {
            inner = new T();
        }

        public Generics(T value)
        {
            inner = value;
        }

        public void Nullify()
        {
            //inner = null;
        }
    }
}
