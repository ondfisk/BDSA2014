using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture05
{
    public class Superhero
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string AlterEgo { get; set; }
        public Gender Gender { get; set; }
        public DateTime FirstAppearance { get; set; }
        public int PostalCode { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} aka {2}", GivenName, Surname, AlterEgo);
        }
    }
}
