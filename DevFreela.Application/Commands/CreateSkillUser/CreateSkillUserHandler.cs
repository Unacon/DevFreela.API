using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateSkillUser
{
    public class CreateSkillUserHandler : IRequestHandler<CreateSkillUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public CreateSkillUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(CreateSkillUserCommand request, CancellationToken cancellationToken)
        {
            UserSkill userSkill = new UserSkill(request.IdUser, request.IdSkill);
            await _userRepository.CreateSkillAsync(userSkill);

            return Unit.Value;
        }
    }
}
