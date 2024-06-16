using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.ActiveUser
{
    public class ActiveUserHandler : IRequestHandler<ActiveUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public ActiveUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(ActiveUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserAsync(request.Id);
            user.ActiveUser(request.Active);

            await _userRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
