using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteSkillUser
{
    public class DeleteSkillUserHandler : IRequestHandler<DeleteSkillUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteSkillUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteSkillUserCommand request, CancellationToken cancellationToken)
        {
            UserSkill userSkill = await _userRepository.GetSkillAsync(request.IdUser, request.IdSkill);

            await _userRepository.DeleteSkillAsync(userSkill);            

            return Unit.Value;
        }
    }
}
