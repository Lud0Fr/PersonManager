using AutoMapper;
using Moq;
using PersonManager.Api.Dtos;
using PersonManager.Api.Queries;
using PersonManager.Domain.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PersonManager.Tests.Queries
{
    public class PersonQueriesTest
    {
        private readonly Mock<IGroupRepository> _PersonRepository;
        private readonly Mock<IMapper> _mapper;

        public PersonQueriesTest()
        {
            _PersonRepository = new Mock<IGroupRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllAsync_Uses_Search_From_IPersonRepository()
        {
            // Arrange
            var sut = new PersonQueries(_PersonRepository.Object, _mapper.Object);
            // Act
            await sut.Search(It.IsAny<string>());
            // Assert
            _PersonRepository.Verify(r => r.Search(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_Uses_Map_From_IMapper()
        {
            // Arrange
            var sut = new PersonQueries(_PersonRepository.Object, _mapper.Object);
            // Act
            await sut.Search(It.IsAny<string>());
            // Assert
            _mapper.Verify(m => m.Map<IEnumerable<PersonDto>>(It.IsAny<IEnumerable<Person>>()), Times.Once);
        }
    }
}
