using DeliverySystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PersonManager.Domain.Persons;
using PersonManager.Tools.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManager.Infrastructure.Repositories
{
    public class PersonManagerRepository :
        RepositoryBase<Group, AppDbContext>,
        IGroupRepository
    {
        public PersonManagerRepository(AppDbContext entities)
            : base(entities)
        { }

        public async Task<IEnumerable<Person>> Search(string keyword)
        {
            return await Query
                .Include(g => g.Persons)
                .SelectMany(g => g.Persons)
                .Include(p => p.Group)
                .Where(p => p.Name.Contains(keyword) || p.Group.Name.Contains(keyword))
                .ToListAsync();
        }
    }
}
