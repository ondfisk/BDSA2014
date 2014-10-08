using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture05
{
    public class Repository
    {
        public IList<Superhero> Superheroes { get; set; }

        public IList<Locality> Localities { get; set; }

        public Repository()
        {
            Localities = new List<Locality> 
            {
                new Locality { PostalCode = 10001, Name = "New York" },
                new Locality { PostalCode = 62960, Name = "Metropolis" },
                new Locality { PostalCode = 53540, Name = "Gotham City" },
                new Locality { PostalCode = 45459, Name = "Dayton" },
                new Locality { PostalCode = 780, Name = "Alberta" }
            };

            Superheroes = new List<Superhero> 
            {
                new Superhero {GivenName = "Clark", Surname = "Kent", AlterEgo = "Superman", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1938-04-18"), PostalCode = 62960 },
                new Superhero {GivenName = "Bruce", Surname = "Wayne", AlterEgo = "Batman", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1939-05-01"), PostalCode = 53540 },
                new Superhero {GivenName = "Wonder Woman", AlterEgo = "Princess Diana of Themyscira", Gender = Gender.Female, FirstAppearance = DateTime.Parse("1941-12-01") },
                new Superhero {GivenName = "Bruce", Surname = "Banner", AlterEgo = "Hulk", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1962-05-01"), PostalCode = 45459 },
                new Superhero {GivenName = "Steve", Surname = "Rogers", AlterEgo = "Captain America", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1941-03-01"), PostalCode = 10001 },
                new Superhero {GivenName = "Tony", Surname = "Stark", AlterEgo = "Iron Man", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1963-03-01"), PostalCode = 10001 },
                new Superhero {GivenName = "James", Surname = "Howlett", AlterEgo = "Wolverine", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1974-10-01"), PostalCode = 780 },
                new Superhero {GivenName = "Selina", Surname = "Kyle", AlterEgo = "Catwoman", Gender = Gender.Female, FirstAppearance = DateTime.Parse("1940-04-01"), PostalCode = 53540 },
            };
        }
    }
}
