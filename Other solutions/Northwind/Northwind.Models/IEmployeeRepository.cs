using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Models
{
    public interface IEmployeeRepository : IDisposable
    {
        Task<ICollection<Contact>> Read();

        Task<byte[]> Portrait(int id);

        Task<Contact> Read(int id);

        Task Update(Contact contact);
    }
}