using System.Data.Entity;

namespace Stuff.Entities
{
    public class StuffContext : DbContext, IStuffContext
    {
        public DbSet<Stuff> Stuff { get; set; }
    }
}
