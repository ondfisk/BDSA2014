using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NorthwindContext _context;

        public EmployeeRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<Employee> Create(Employee employee)
        {
            var entity = new Entities.Employee
            {
                Id = employee.Id,
                GivenName = employee.GivenName,
                Surname = employee.Surname,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate
            };

            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();

            return await Read(entity.Id);
        }

        public IQueryable<Employee> Read()
        {
            var employees = from e in _context.Employees
                            select new Employee
                            {
                                Id = e.Id,
                                Title = e.Title,
                                TitleOfCourtesy = e.TitleOfCourtesy,
                                GivenName = e.GivenName,
                                Surname = e.Surname,
                                BirthDate = e.BirthDate,
                                HireDate = e.HireDate
                            };

            return employees;
        }

        public async Task<Employee> Read(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return null;
            }

            return new Employee
            {
                Id = employee.Id,
                GivenName = employee.GivenName,
                Surname = employee.Surname,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate
            };
        }

        public async Task<bool> Update(Employee employee)
        {
            var entity = await _context.Employees.FindAsync(employee.Id);

            if (entity == null)
            {
                return false;
            }

            entity.GivenName = employee.GivenName;
            entity.Surname = employee.Surname;
            entity.Title = employee.Title;
            entity.TitleOfCourtesy = employee.TitleOfCourtesy;
            entity.BirthDate = employee.BirthDate;
            entity.HireDate = employee.HireDate;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ValidationException)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Employees.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
