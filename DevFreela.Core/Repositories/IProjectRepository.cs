using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();

        Task<Project> GetByIdProjectAsync(int id);

        Task<List<ProjectComment>> GetProjectCommentsAsync(int id);

        Task CreateCommentdAsync(ProjectComment request);

        Task CreateProjectAsync(Project request);

        Task SaveChangeAsync();
    }
}
