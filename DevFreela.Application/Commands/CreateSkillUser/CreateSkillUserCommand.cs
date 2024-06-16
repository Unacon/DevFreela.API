using MediatR;

namespace DevFreela.Application.Commands.CreateSkillUser
{
    public class CreateSkillUserCommand : IRequest<Unit>
    {
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
    }
}
