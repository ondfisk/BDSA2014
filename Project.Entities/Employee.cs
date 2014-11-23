using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string PasswordHash { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        public ICollection<Car> Sales { get; set; } 
    }
}
