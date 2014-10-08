using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture06
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var repo = new CalendarContext())
            {
                var important = from a in repo.Appointments
                    select new
                    {
                        a.Subject,
                        Category = a.Category.Name
                    };

                important.ToList().ForEach(a => Console.WriteLine("{0} ({1})", a.Subject, a.Category));
            }
        }
        
        private static void OldSchool()
        {
            var oldSchool = new OldSchool();

            var product = oldSchool.Read(4);

            Console.WriteLine(product.Name);

            Console.Write("".PadLeft(80, '-'));

            var products = oldSchool.Read();

            products.Print();
        }
    }
}
 