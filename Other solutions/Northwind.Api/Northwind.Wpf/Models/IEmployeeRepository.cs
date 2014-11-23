using System;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Wpf.Models
{
    public interface IEmployeeRepository : IDisposable
    {
        Task<Employee> Create(Employee employee);

        IQueryable<Employee> Read();

        Task<Employee> Read(int id);

        Task<bool> Update(Employee employee);

        Task<bool> Delete(int id);
    }
}