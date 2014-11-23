using System.Data.Entity;

namespace Northwind.Entities
{
    public class NorthwindContext : DbContext, INorthwindContext
    {
        static NorthwindContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<NorthwindContext>());
        }

        public NorthwindContext()
            : base("name=Northwind")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.DirectReports)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.ReportsTo);
        }
    }
}
