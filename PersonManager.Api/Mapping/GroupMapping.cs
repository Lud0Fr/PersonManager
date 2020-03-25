using AutoMapper;
using PersonManager.Api.Dtos;
using PersonManager.Domain.Persons;

namespace PersonManager.Api.Mapping
{
    public class GroupMapping : Profile
    {
        public GroupMapping()
        {
            CreateMap<Group, GroupDto>();
        }
    }
}
