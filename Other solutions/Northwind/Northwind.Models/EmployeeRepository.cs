using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly INorthwindContext _context;

        public EmployeeRepository(INorthwindContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Contact>> Read()
        {
            var employees = from e in _context.Employees
                orderby e.FirstName, e.LastName
                select new Contact
                {
                    Id = e.EmployeeID,
                    Title = e.Title,
                    TitleOfCourtesy = e.TitleOfCourtesy,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Extension = e.Extension
                };

            return await employees.ToListAsync();
        }

        public async Task<byte[]> Portrait(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return null;
            }

            return employee.Photo.Skip(78).ToArray();
        }

        public async Task<Contact> Read(int id)
        {
            var employees = from e in _context.Employees
                            where e.EmployeeID == id
                            select new Contact
                            {
                                Id = e.EmployeeID,
                                Title = e.Title,
                                TitleOfCourtesy = e.TitleOfCourtesy,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Extension = e.Extension
                            };

            return await employees.FirstOrDefaultAsync();
        }

        public async Task Update(Contact contact)
        {
            var employee = await _context.Employees.FindAsync(contact.Id);

            employee.FirstName = contact.FirstName;
            employee.LastName = contact.LastName;

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
