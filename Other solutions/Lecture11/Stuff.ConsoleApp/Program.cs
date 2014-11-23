using System;
using Stuff.Entities;

namespace Stuff.ConsoleApp
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
