using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stuff.Entities;

namespace Stuff.Models
{
    public class StuffRepository : IDisposable
    {
        private readonly IStuffContext _context;

        public StuffRepository(IStuffContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<ICollection<StuffDto>> GetAllGoodStuff()
        {
            var goodStuff = from s in _context.Stuff
                where s.Cool
                select new StuffDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Cool = s.Cool
                };

            return await goodStuff.ToListAsync();
        }
    }
}
