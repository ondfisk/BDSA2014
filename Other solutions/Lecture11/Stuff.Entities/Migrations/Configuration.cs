using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Stuff.Entities.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<StuffContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StuffContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var good = new Stuff {Id = 1, Name = "Good stuff", Cool = true};
            var bad = new Stuff { Id = 2, Name = "Bad stuff", Cool = false };

            context.Stuff.AddOrUpdate(s => s.Id, good, bad);
        }
    }
}
