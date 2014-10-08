using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lecture01
{
    public static class Types
    {
        private const string Format = "{0,-12} {1,-12} {2,-32} {3, -32}";

        public static void MainT()
        {
            
            Console.WindowWidth = 100;
            Console.WriteLine("C# types:");
            Console.WriteLine(Format, "C# Name", ".NET Name", "Min Value", "Max Value");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth, '-'));

            var types = new Dictionary<string, Type> {
                {"byte", typeof(byte)},
                {"short", typeof(short)},
                {"int", typeof(int)},
                {"long", typeof(long)},
                {"float", typeof(float)},
                {"double", typeof(double)},
                {"decimal", typeof(decimal)},
                {"sbyte", typeof(sbyte)},
                {"ushort", typeof(ushort)},
                {"uint", typeof(uint)},
                {"ulong", typeof(ulong)}
            };
           
            types.ToList().ForEach(t => PrintNumericType(t.Key, t.Value));

            Console.WriteLine(Format, typeof(char).Name, "char", char.MinValue + " (" + (ushort)char.MinValue + ")", char.MaxValue + " (" + (ushort)char.MaxValue + ")");
            Console.WriteLine(Format, typeof(bool).Name, "bool", "false", "true");

            Console.WriteLine();
            Console.WriteLine(Format, typeof(string).Name, "string", null, null);
            Console.WriteLine(Format, typeof(object).Name, "object", null, null);
            
            Console.WriteLine();
            Console.WriteLine(".NET Types:");
            Console.Write(string.Empty.PadLeft(Console.WindowWidth, '-'));

            PrintNumericType(null, typeof(DateTime));
            Console.WriteLine(Format, typeof(BigInteger).Name, null, "Arbitrarily small(!)", "Arbitrarily large(!)");
        }

        private static void PrintNumericType(string cSharpName, Type t)
        {
            var minValue = t.GetField("MinValue").GetValue(null);
            var maxValue = t.GetField("MaxValue").GetValue(null);

            Console.WriteLine(Format, t.Name, cSharpName, minValue, maxValue);
        }
    }
}
