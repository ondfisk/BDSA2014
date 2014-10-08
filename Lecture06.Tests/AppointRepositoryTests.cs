using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lecture06.Tests
{
    [TestFixture]
    public class AppointRepositoryTests
    {
        [Test]
        public void Read_1_Returns_Appointment()
        {
        }
    }

    public class FakeContext : ICalendarContext
    {
        public IDbSet<Appointment> Appointments { get; set; }

        public IDbSet<AppointmentCategory> AppointmentCategories { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {
        }

        public FakeContext()
        {
        }
    }
}
