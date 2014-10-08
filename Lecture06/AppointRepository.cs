using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture06
{
    public class AppointRepository : IDisposable
    {
        private readonly ICalendarContext _context;

        public AppointRepository(ICalendarContext context = null)
        {
            _context = context ?? new CalendarContext();
        }

        public Appointment Read(int id)
        {
            return _context.Appointments.Find(id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
