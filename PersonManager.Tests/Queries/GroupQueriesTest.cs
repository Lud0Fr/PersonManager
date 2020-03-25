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
    public class GroupQueriesTest
    {
        private readonly Mock<IGroupRepository> _groupRepository;
        private readonly Mock<IMapper> _mapper;

        public GroupQueriesTest()
        {
            _groupRepository = new Mock<IGroupRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetAllAsync_Uses_GetAllAsync_From_IGroupRepository()
        {
            // Arrange
            var sut = new GroupQueries(_groupRepository.Object, _mapper.Object);
            // Act
            await sut.GetAllAsync();
            // Assert
            _groupRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_Uses_Map_From_IMapper()
        {
            // Arrange
            var sut = new GroupQueries(_groupRepository.Object, _mapper.Object);
            // Act
            await sut.GetAllAsync();
            // Assert
            _mapper.Verify(m => m.Map<IEnumerable<GroupDto>>(It.IsAny<IEnumerable<Group>>()), Times.Once);
        }
    }
}
