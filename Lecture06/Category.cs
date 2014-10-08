using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Lecture06
{
    public class Category
    {
        [Column("CategoryID")]
        public int Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; } 
    }
}
