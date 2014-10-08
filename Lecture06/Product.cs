using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Lecture06
{
    public class Product
    {
        [Column("ProductID")]
        public int Id { get; set; }

        [Column("ProductName")]
        [Required]
        public string Name { get; set; }

        [Column("UnitPrice")]
        public decimal? Price { get; set; }

        [Column("CategoryID")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
