using MediatR;

namespace PersonManager.Api.Commands
{
    public class AddPersonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int GroupId { get; set; }
    }
}
