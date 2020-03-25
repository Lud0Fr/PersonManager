using MediatR;
using PersonManager.Api.Commands;
using PersonManager.Domain.Persons;
using PersonManager.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace PersonManager.Api.CommandHandlers
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, int>
    {
        private readonly IGroupRepository _PersonManagerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonCommandHandler(
            IGroupRepository PersonManagerRepository,
            IUnitOfWork unitOfWork)
        {
            _PersonManagerRepository = PersonManagerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(
            AddPersonCommand request,
            CancellationToken cancellationToken)
        {
            var group = await GetGroup(request.GroupId);
            var person = Person.New(request.Name, request.GroupId);

            group.AddPerson(person);

            _PersonManagerRepository.Update(group);

            await _unitOfWork.SaveAllAsync();

            return person.Id;
        }

        private async Task<Group> GetGroup(int groupId)
        {
            var group = await _PersonManagerRepository.GetAsync(groupId);

            return group == null
                ? throw new ValidationException($"Group with id {groupId} not found")
                : group;
        }
    }
}
