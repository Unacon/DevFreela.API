using MediatR;

namespace DevFreela.Application.Commands.ActiveUser
{
    public class ActiveUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
