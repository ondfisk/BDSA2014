using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public interface INorthwindContext : IDisposable
    {
        DbSet<Employee> Employees { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}