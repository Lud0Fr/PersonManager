using AutoMapper;
using PersonManager.Api.Dtos;
using PersonManager.Domain.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonManager.Api.Queries
{
    #region Interface

    public interface IGroupQueries
    {
        Task<IEnumerable<GroupDto>> GetAllAsync();
    }

    #endregion

    public class GroupQueries : IGroupQueries
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupQueries(
            IGroupRepository groupRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(
                await _groupRepository.GetAllAsync());
        }
    }
}
