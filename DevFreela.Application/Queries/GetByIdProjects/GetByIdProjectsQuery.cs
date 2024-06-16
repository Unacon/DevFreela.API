using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdProjects
{
    public class GetByIdProjectsQuery : IRequest<Project>
    {
        public GetByIdProjectsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
