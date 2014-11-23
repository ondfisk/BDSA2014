using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stuff.Entities;

namespace Stuff.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new StuffContext())
            {
                foreach (var stuff in ctx.Stuff)
                {
                    Console.WriteLine(stuff.Name);
                }
            }
        }
    }
}
