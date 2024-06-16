using MediatR;

namespace DevFreela.Application.Commands.DeleteSkillUser
{
    public class DeleteSkillUserCommand : IRequest<Unit>
    {
        public DeleteSkillUserCommand(int idUser, int idSkill)
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
    }
}
