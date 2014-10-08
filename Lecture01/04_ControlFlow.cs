using System;

namespace Lecture01
{
    public static class ControlFlow
    {
        public static void Break(string[] arr)
        {
            bool found = false;
            foreach (string s in arr)
            {
                if (s == "")
                {
                    found = true;
                    break;
                }
            }
            Console.WriteLine(found);
        }

        public static void Continue(string[] arr)
        {
            foreach (string s in arr)
            {
                if (s == "")
                {
                    continue;
                }
                Console.WriteLine(s);
            }
        }

        public static void LabelGoto(int magicNumber)
        {
            if (magicNumber == 42)
            {
                goto haywire;
            }
            Console.WriteLine("Not a magic number...");

            haywire:
            Console.WriteLine("Magic!!!");
        }
    }
}
