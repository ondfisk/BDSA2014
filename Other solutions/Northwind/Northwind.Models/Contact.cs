using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "Surname")]
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

        [StringLength(4)]
        public string Extension { get; set; }
    }
}