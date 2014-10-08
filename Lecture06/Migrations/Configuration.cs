namespace Lecture06.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lecture06.CalendarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Lecture06.CalendarContext";
        }

        protected override void Seed(Lecture06.CalendarContext context)
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

            context.AppointmentCategories.AddOrUpdate(new[]
            {
                new AppointmentCategory { Id = 1, Name = "Important" },
                new AppointmentCategory { Id = 2, Name = "Very silly" }
            });

            context.Appointments.AddOrUpdate(new[]
            {
                new Appointment { Id = 1, Subject = "Appointment 1", Start = DateTime.Parse("2012-12-01 10:00"), Duration = 120, CategoryId = 1 },
                new Appointment { Id = 2, Subject = "Appointment 2", Start = DateTime.Parse("2012-12-02 10:00"), Duration = 120, CategoryId = 2 },
                new Appointment { Id = 3, Subject = "Appointment 3", Start = DateTime.Parse("2012-12-03 10:00"), Duration = 120 },
                new Appointment { Id = 4, Subject = "Appointment 4", Start = DateTime.Parse("2012-12-04 10:00"), Duration = 120 },
                new Appointment { Id = 5, Subject = "Appointment 5", Start = DateTime.Parse("2012-12-05 10:00"), Duration = 120 },
                new Appointment { Id = 6, Subject = "Appointment 6", Start = DateTime.Parse("2012-12-06 10:00"), Duration = 120 }
            });
        }
    }
}
