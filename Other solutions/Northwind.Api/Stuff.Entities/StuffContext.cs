using System.Data.Entity;

namespace Stuff.Entities
{
    public class StuffContext : DbContext
    {
        public DbSet<Stuff> Stuff { get; set; }
    }
}