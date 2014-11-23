using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Entities
{
    public class Employee
    {
        public Employee()
        {
            DirectReports = new HashSet<Employee>();
        }

        [Column("EmployeeID")]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string HomePhone { get; set; }

        [StringLength(4)]
        public string Extension { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public int? ReportsTo { get; set; }

        [StringLength(255)]
        public string PhotoPath { get; set; }

        [NotMapped]
        public string FullName 
        {
            get { return string.Format("{0} {1}, {2}", FirstName, LastName, Title); }
        }

        public virtual ICollection<Employee> DirectReports { get; set; }

        public virtual Employee Manager { get; set; }
    }
}
