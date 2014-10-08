using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture06
{
    public interface ICalendarContext : IDisposable
    {
        IDbSet<Appointment> Appointments { get; set; }
        IDbSet<AppointmentCategory> AppointmentCategories { get; set; }
        int SaveChanges();
    }

    public class CalendarContext : DbContext, ICalendarContext
    {
        public IDbSet<Appointment> Appointments { get; set; }

        public IDbSet<AppointmentCategory> AppointmentCategories { get; set; }
    }
}
