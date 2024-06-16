using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetProjectComments
{
    public class GetProjectCommentsQueryHandler : IRequestHandler<GetProjectCommentsQuery, List<ProjectComment>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectCommentsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<List<ProjectComment>> Handle(GetProjectCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetProjectCommentsAsync(request.Id);
            
        }
    }
}
