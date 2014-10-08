using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lecture06
{
    public class AppointmentCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Appointment> Appointments { get; set; } 
    }

    public class Appointment
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public DateTime Start { get; set; }

        public int Duration { get; set; }

        public int? CategoryId { get; set; }

        public virtual AppointmentCategory Category { get; set; }
    }
}
