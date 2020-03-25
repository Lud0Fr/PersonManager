using AutoMapper;
using PersonManager.Api.Dtos;
using PersonManager.Domain.Persons;

namespace PersonManager.Api.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Person, PersonDto>();
        }
    }
}
