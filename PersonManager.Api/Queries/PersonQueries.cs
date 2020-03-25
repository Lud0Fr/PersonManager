using AutoMapper;
using PersonManager.Api.Dtos;
using PersonManager.Domain.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManager.Api.Queries
{
    #region Interface

    public interface IPersonQueries
    {
        Task<IEnumerable<PersonDto>> Search(string keyword);
    }

    #endregion

    public class PersonQueries : IPersonQueries
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public PersonQueries(
            IGroupRepository groupRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDto>> Search(string keyword)
        {
            return _mapper.Map<IEnumerable<PersonDto>>(
                await _groupRepository.Search(keyword));
        }
    }
}
