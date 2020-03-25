using Moq;
using PersonManager.Api.CommandHandlers;
using PersonManager.Api.Commands;
using PersonManager.Domain.Persons;
using PersonManager.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PersonManager.Tests.CommandHandlers
{
    public class AddPersonCommandHandlerTest
    {
        private readonly Mock<IGroupRepository> _PersonManagerRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AddPersonCommandHandlerTest()
        {
            _PersonManagerRepository = new Mock<IGroupRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Handle_Uses_GetAsync_From_IGroupRepository_To_Retrieve_The_Group_By_Id()
        {
            // Arrange
            _PersonManagerRepository.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync(NewGroup());
            var sut = new AddPersonCommandHandler(_PersonManagerRepository.Object, _unitOfWork.Object);
            // Act
            await sut.Handle(NewAddPersonCommand(), new CancellationToken());
            // Assert
            _PersonManagerRepository.Verify(r => r.GetAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Handle_Throw_A_ValidationException_When_No_Group_Found()
        {
            // Arrange
            var sut = new AddPersonCommandHandler(_PersonManagerRepository.Object, _unitOfWork.Object);
            // Assert
            Assert.ThrowsAsync<ValidationException>(() => sut.Handle(NewAddPersonCommand(), new CancellationToken()));
        }

        [Fact]
        public async Task Handle_Uses_Update_From_IGroupRepository_To_Update_The_Group_Into_The_Context()
        {
            // Arrange
            _PersonManagerRepository.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync(NewGroup());
            var sut = new AddPersonCommandHandler(_PersonManagerRepository.Object, _unitOfWork.Object);
            // Act
            await sut.Handle(NewAddPersonCommand(), new CancellationToken());
            // Assert
            _PersonManagerRepository.Verify(r =>
                r.Update(It.Is<Group>(g => g.Persons.Any())), Times.Once);
        }

        [Fact]
        public async Task Handle_Uses_SaveAllAsync_From_IUnitOfWork_To_Save_Into_The_Database()
        {
            // Arrange
            _PersonManagerRepository.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync(NewGroup());
            var sut = new AddPersonCommandHandler(_PersonManagerRepository.Object, _unitOfWork.Object);
            // Act
            await sut.Handle(NewAddPersonCommand(), new CancellationToken());
            // Assert
            _unitOfWork.Verify(u => u.SaveAllAsync(), Times.Once);
        }

        private Group NewGroup()
        {
            return Group.New("New group");
        }

        private AddPersonCommand NewAddPersonCommand()
        {
            return new AddPersonCommand
            {
                Name = "New name",
                GroupId = 1
            };
        }
    }
}
