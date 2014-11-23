using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities
{
    public class Customer
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

        [StringLength(50)]
        public string Telephone { get; set; }

        public ICollection<Order> Purchases { get; set; }
    }
}