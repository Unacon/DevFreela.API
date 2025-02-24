﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateFreelancerUser
{
    public class CreateFreelancerUserHandler : IRequestHandler<CreateFreelancerUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;

        public CreateFreelancerUserHandler(IUserRepository userRepository, IProjectRepository projectRepository)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(CreateFreelancerUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserAsync(request.Id);
            Project project = await _projectRepository.GetByIdProjectAsync(request.IdProject);

            UserOwendProject userOwendProject = new UserOwendProject(user.Id, project.Id);

            project.UpdateFreelancer(user.Id);
            await _userRepository.SaveChangeAsync();

            return Unit.Value;

        }
    }
}
