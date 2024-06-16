using MediatR;

namespace DevFreela.Application.Commands.CreateFreelancerUser
{
    public class CreateFreelancerUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdProject { get; set; }
    }
}
