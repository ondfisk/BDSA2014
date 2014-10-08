using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture06
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        static NorthwindContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<NorthwindContext>());
        }
    }
}
