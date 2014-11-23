using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Lecture09.Entities
{
    public interface INorthwindContext : IDisposable
    {
        DbSet<Employee> Employees { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}