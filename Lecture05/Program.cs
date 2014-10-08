using System.Collections;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture05
{
    class Program
    {
        static readonly IList<Superhero> _superheroes;
        static readonly IList<Locality> _localities;

        static Program()
        {
            var repository = new Repository();
            _superheroes = repository.Superheroes;
            _localities = repository.Localities;
        }

        static void Main(string[] args)
        {
            CustomLinq();
        }

        static void Select()
        {
            var heroes = from h in _superheroes
                         select h;

            var heroes2 = _superheroes.AsEnumerable();

            var names = from h in _superheroes
                        select h.GivenName;

            var names2 = _superheroes.Select(h => h.GivenName);

            var fullNames = from h in _superheroes
                            select string.Concat(h.GivenName, " ", h.Surname);

            var fullNames2 = _superheroes.Select(h => h.GivenName + " " + h.Surname);

            var projection = from h in _superheroes
                             select new { Name = h.GivenName + " " + h.Surname, AlterEgo = h.AlterEgo };

            var projection2 = _superheroes.Select(h => new { Name = h.GivenName + " " + h.Surname, h.AlterEgo });
        }

        static void Where()
        {
            var repository = new Repository();

            var females = from h in _superheroes
                          where h.Gender == Gender.Female
                          select h;

            var females2 = _superheroes.Where(h => h.Gender == Gender.Female);

            var femaleGivenNames = from h in _superheroes
                                   where h.Gender == Gender.Female
                                   select h.GivenName;

            var femaleGivenNames2 = _superheroes.Where(h => h.Gender == Gender.Female)
                                                .Select(h => h.GivenName);

            var projection = from h in _superheroes
                             where h.Gender == Gender.Male
                             select new
                             {
                                 Hero = h.AlterEgo,
                                 Age = Age(h.FirstAppearance)
                             };

            var projection2 = _superheroes.Where(h => h.Gender == Gender.Male)
                                          .Select(h => new { Hero = h.AlterEgo, Age = Age(h.FirstAppearance) });

            var old = from h in _superheroes
                      where Age(h.FirstAppearance) >= 70
                      select h;

            var old2 = _superheroes.Where(h => Age(h.FirstAppearance) >= 70);
        }

        static int Age(DateTime birthday)
        {
            return (int)DateAndTime.DateDiff(DateInterval.Year, birthday, DateTime.Now);
        }

        static void Let()
        {
            var longNames = from h in _superheroes
                            where (h.GivenName + " " + h.Surname).Length > 10
                            select h.GivenName + " " + h.Surname;

            var longNames2 = from h in _superheroes
                             let name = h.GivenName + " " + h.Surname
                             where name.Length > 10
                             select new { AlterEgo = h.AlterEgo, Name = name };

            var temp = _superheroes.Select(h => new { H = h, Name = h.GivenName + " " + h.Surname });

            var longNames3 = temp.Where(t => t.Name.Length > 10).Select(h => h.Name);
        }

        static void OrderBy()
        {
            var sorted = from h in _superheroes
                         orderby h.GivenName ascending
                         select h;

            var sorted2 = _superheroes.OrderBy(h => h.GivenName);

            var sortedMore = from h in _superheroes
                             orderby h.GivenName, h.Surname
                             select h;

            var sortedMore2 = _superheroes.OrderBy(h => h.GivenName).ThenBy(h => h.Surname);

            var backwards = from h in _superheroes
                            orderby h.AlterEgo descending
                            select h;

            var backwards2 = _superheroes.OrderByDescending(h => h.AlterEgo);

            var sortedByFullName = from h in _superheroes
                                   let name = h.GivenName + " " + h.Surname
                                   orderby name
                                   select name;

            var malesSortedByFullName = from h in _superheroes
                                        let name = h.GivenName + " " + h.Surname
                                        where h.Gender == Gender.Male
                                        orderby name
                                        select name;
        }

        static void GroupBy()
        {
            var group = from s in _superheroes
                        group s by s.Gender;

            var group2 = _superheroes.GroupBy(g => g.Gender);

            var groupedAndOrdered = from s in _superheroes
                                    orderby s.GivenName, s.Surname
                                    group s by s.PostalCode;

            var groupedAndOrdered2 = _superheroes.OrderBy(s => s.GivenName)
                                                 .ThenBy(k => k.Surname)
                                                 .GroupBy(v => v.PostalCode);

            var continuation = from s in _superheroes
                               orderby s.AlterEgo
                               group s by s.PostalCode
                                   into g
                                   select g.Key;

            var twoStep1 = from s in _superheroes
                           orderby s.AlterEgo
                           group s by s.PostalCode;

            var twoStep2 = from g in twoStep1
                           select g.Key;
        }

        static void MultipleSources()
        {
            int[] evens = { 2, 4, 6 };
            int[] odds = { 1, 3, 5 };

            var products = from e in evens
                           from o in odds
                           select e * o;

            products.Print();

            var cartesianProduct = from e in evens
                                   from o in odds
                                   select new { e, o };

            cartesianProduct.Print();
        }

        static void Join()
        { 
            // SQL: 
            // SELECT h.GivenName + ' ' + h.Surname AS Name, h.AlterEgo, l.Name AS Locality
            // FROM SuperHeroes AS h JOIN Localities AS l ON h.PostalCode = l.PostalCode

            var heroes = from h in _superheroes
                         join l in _localities on h.PostalCode equals l.PostalCode
                         select new
                         {
                             Name = string.Join(" ", h.GivenName, h.Surname),
                             AlterEgo = h.AlterEgo,
                             Locality = l.Name
                         };

            var heroesLeftJoin = from h in _superheroes
                                 let c = _localities.FirstOrDefault(l => l.PostalCode == h.PostalCode)
                                 let n = c == null ? null : c.Name
                                 select new
                                 {
                                     Name = string.Join(" ", h.GivenName, h.Surname),
                                     AlterEgo = h.AlterEgo,
                                     Locality = n
                                 };

            Console.WriteLine("{0,-20} {1,-40} {2}", "Name", "Alter Ego", "Locality");
            Console.Write(string.Empty.PadRight(80, '-'));
            foreach (var hero in heroes)
            {
                Console.WriteLine("{0,-20} {1,-40} {2}", hero.Name, hero.AlterEgo, hero.Locality);
            }
        }

        static void JoinCompositeKeys()
        { 
            var query = from h in _superheroes
                        join l in _localities 
                            on new {GivenName = h.GivenName, Surname = h.GivenName} 
                            equals new { GivenName = l.PostalCode.ToString(), Surname = l.Name }
                        select new { l.PostalCode }; 
        }
        static void SkipTake()
        {
            var all = _superheroes.OrderBy(s => s.AlterEgo);
            all.Print("All");

            var take2 = _superheroes.OrderBy(s => s.AlterEgo).Take(2);
            take2.Print("Take 2");

            var skip2 = _superheroes.OrderBy(s => s.AlterEgo).Skip(2);
            skip2.Print("Skip 2");

            var skip2take2 = _superheroes.OrderBy(s => s.AlterEgo).Skip(2).Take(2);
            skip2take2.Print("Skip 2 then Take 2");

            var linq = (from h in _superheroes 
                        orderby h.AlterEgo
                        select h).Skip(2).Take(2);

            var some = _superheroes.OrderBy(n => n.GivenName)
                                   .ThenBy(n => n.Surname)
                                   .SkipWhile(n => n.GivenName.StartsWith("B"))
                                   .TakeWhile(n => !n.GivenName.StartsWith("W"));
            some.Print("Between C and V");
        }

        static void Distinct()
        {
            int[] numbers = { 1, 2, 3, 3, 4, 2, 1, 0, 0, 3, 5, 3 };

            var distinct = numbers.Distinct();

            distinct.Print();
        }

        static void Aggregates()
        {
            int[] numbers = { 1, 2, 3, 3, 4, 2, 1, 0, 0, 3, 5, 3 };

            var count = numbers.Count();
            var min = numbers.Min();
            var max = numbers.Max();
            var average = numbers.Average();

            Console.WriteLine("Numbers: {0}", string.Join(", ", numbers));

            Console.WriteLine("Count:   {0}", count);
            Console.WriteLine("Min:     {0}", min);
            Console.WriteLine("Max:     {0}", max);
            Console.WriteLine("Average: {0}", average);

            var sumPostal = _superheroes.Sum(p => p.PostalCode);

            // Custom Aggregate
            var sumOfEvens = numbers.Aggregate(0, (a, b) =>
            {
                if (b % 2 == 0)
                {
                    return a + b;
                }
                else
                {
                    return a;
                }
            });

            Console.WriteLine("SumOfEvens: {0} (should be: {1})", sumOfEvens, numbers.Where(n => n % 2 == 0).Sum());

            var factorial = Enumerable.Range(1, 10).Aggregate(1, (a, b) => a * b);
        }

        static void FirstLastSingle()
        {
            int[] numbers = { 1, 2, 3, 3, 4, 2, 1, 0, 0, 3, 5, 3 };

            var first = numbers.First();

            var firstEven = numbers.First(n => n % 2 == 0);

            var last = numbers.Last();

            var lastOdd = numbers.Last(n => n % 2 == 1);

            var firstDefault = _superheroes.FirstOrDefault(h => h.GivenName == "Bruce");

            var lastHero = _superheroes.Last(h => h.PostalCode > 1000000);

            var lastDefaultHero = _superheroes.LastOrDefault(h => h.PostalCode > 1000000);

            var singleBruce = _superheroes.Single(h => h.GivenName == "Bruce");

            var singleXXX = _superheroes.Single(h => h.GivenName == "XXX");

            var singleOrDefaultXXX = _superheroes.SingleOrDefault(h => h.GivenName == "XXX");

            var singleOrDefaultClark = _superheroes.SingleOrDefault(h => h.GivenName == "Clark");

            var singleOrDefaultBruce = _superheroes.SingleOrDefault(h => h.GivenName == "Bruce");
        }

        static void Set()
        {
            int[] odds = { 1, 3, 5, 7, 9 };
            int[] evens = { 2, 4, 6, 8, 10 };
            int[] oneToFive = Enumerable.Range(1, 5).ToArray();
            int[] sixToTen = Enumerable.Range(6, 10).ToArray();

            // Concatenate two sets:
            var concat = odds.Concat(evens);
            concat.Print("odds.Concat(evens)");

            var concat2 = odds.Concat(oneToFive);
            concat2.Print("odds.Concat(oneToFive)");

            // Union:
            var union = odds.Union(oneToFive);
            concat.Print("odds.Union(oneToFive)");

            // Intersect 
            var intersect = sixToTen.Intersect(evens);
            intersect.Print("sixToTen.Intersect(evens)");
        }

        static void AnyAll()
        {
            var isBatmanThere = _superheroes.Any(s => s.AlterEgo == "Batman");

            var areAllSuperheroesMale = _superheroes.All(s => s.Gender == Gender.Male);
        }

        static void OtherStuff()
        {
            int[] l1 = { 1, 3, 5, 7, 9 };
            int[] l2 = { 1, 3, 5, 7, 9 };

            var same = l1.SequenceEqual(l2);
            Console.WriteLine("l1 equals l2: {0}", same);

            var l3 = l2.Reverse();
            var sameReverse = l1.SequenceEqual(l3);
            Console.WriteLine("l1 equals l3: {0}", sameReverse);

            var dictionary = _superheroes.ToDictionary(h => h.AlterEgo);

            // var dictionary2 = _superheroes.ToDictionary(h => h.GivenName);

            var dictionary3 = _superheroes.ToDictionary(h => new { h.GivenName, h.Surname });

            var lookup = _superheroes.ToLookup(h => h.GivenName);

            var array = _superheroes.ToArray();

            var list = _superheroes.ToList();

            var enumerable = _superheroes.AsEnumerable();

            var queryable = _superheroes.AsQueryable();

            string[] codes = { "AL", "AK", "AZ", "AR", "CA" };
            string[] states = 
            {
               "Alabama", 
               "Alaska", 
               "Arizona", 
               "Arkansas", 
               "California",
            };

            var codesWithStates = codes.Zip(states, (code, state) => code + ": " + state);
            codesWithStates.Print("Codes with states");
        }

        static void Deferred()
        {
            string[] states = 
            {
               "Alabama", 
               "Alaska", 
               "Arizona", 
               "Arkansas", 
               "California" 
            };

            var cStates = from s in states
                          where s.StartsWith("C")
                          select s;

            cStates.Print("Before");

            states[0] = "Colorado";

            cStates.Print("After");
        }

        class Supervillain : Superhero
        {
            public int Cool { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1} aka {2} cool: {3}", GivenName, Surname, AlterEgo, Cool);
            }
        }

        static void CastOfType()
        {
            var badGuys = new ArrayList 
            {
                new Supervillain { GivenName = "Norman", Surname = "Osborn", AlterEgo = "Green Goblin", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1964-07-07"), Cool = 1 },
                new Supervillain { GivenName = "Jack", Surname = "Napier", AlterEgo = "Joker", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1940-04-25"), Cool = 10 },
                new Supervillain { GivenName = "Ernst Stavro", Surname = "Blofeld", AlterEgo = "Number 1", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1963-10-10"), Cool = 1000 },
            };
            // badGuys.Cast<Supervillain>().Print("Bad guys");

            var objects = new[] 
            {
                new Superhero { GivenName = "Peter", Surname = "Parker", AlterEgo = "Spider-Man", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1962-08-01") },
                new Supervillain { GivenName = "Anakin", Surname = "Skywalker", AlterEgo = "Darth Vader", Gender = Gender.Male, FirstAppearance = DateTime.Parse("1977-05-25"), Cool = 500 },
                new object(),
                4.2,
                42
            };

            var cast = objects.Cast<Superhero>();
            cast.Print();

            var heroes = objects.OfType<Superhero>();
            heroes.Print("Heroes");

            var villains = objects.OfType<Supervillain>();
            villains.Print("Villains");
        }

        static void SelectMany()
        {
            var jagged = new[] 
            { 
                new[] { 1, 2, 3, 4, 5 },
                new[] { 6, 7, 8, 9, 10 }
            };
            jagged.Print();

            var flat = jagged.SelectMany(i => i);

            flat.Print();
        }

        static void CustomLinq()
        {
            var orderByThenBy = _superheroes.OrderBy(h => h.GivenName).ThenBy(h => h.Surname);
            orderByThenBy.Print("orderByThenBy");

            var doubleSort = _superheroes.DoubleSort(h => h.GivenName, h => h.Surname);
            doubleSort.Print("doubleSort");

            var multiSort = _superheroes.MultiSort(h => h.Gender, h => h.GivenName, h => h.Surname);
            multiSort.Print("multiSort");
        }
    }
}
 