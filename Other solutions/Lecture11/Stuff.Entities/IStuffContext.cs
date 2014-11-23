using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Stuff.Entities
{
    public interface IStuffContext : IDisposable
    {
        DbSet<Stuff> Stuff { get; set; }
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}