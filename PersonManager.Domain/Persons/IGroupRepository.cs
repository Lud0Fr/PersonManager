using PersonManager.Tools.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManager.Domain.Persons
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<IEnumerable<Person>> Search(string keyword);
    }
}
