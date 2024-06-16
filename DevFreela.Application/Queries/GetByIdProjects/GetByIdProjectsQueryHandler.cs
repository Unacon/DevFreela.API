using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdProjects
{
    public class GetByIdProjectsQueryHandler : IRequestHandler<GetByIdProjectsQuery, Project>
    {

        private readonly IProjectRepository _projectRepository;

        public GetByIdProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Project> Handle(GetByIdProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetByIdProjectAsync(request.Id);
        }
    }
}
