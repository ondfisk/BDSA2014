using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int CarId { get; set; }

        public int EmployeeId { get; set; }

        public int CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public decimal SalesPrice { get; set; }

        public Employee Employee { get; set; }

        public Customer Customer { get; set; }

        public Car Car { get; set; }
    }
}
