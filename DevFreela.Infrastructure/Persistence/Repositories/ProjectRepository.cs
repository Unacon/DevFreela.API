using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdProjectAsync(int id)
        {
            Project project = await _dbContext.Projects
              .Include(item => item.Client)
              .Include(item => item.Freelancer)
              .SingleOrDefaultAsync(item => item.Id == id);

            return project;
        }

        public async Task<List<ProjectComment>> GetProjectCommentsAsync(int id)
        {
            List<ProjectComment> projectCommentject = await _dbContext.ProjectComments.Where(p => p.Id == id)?.ToListAsync();
            List<ProjectComment> projectCommentsViewModel = projectCommentject.Select(p => new ProjectComment(p.Content, p.IdProject, p.IdUser)).ToList();

            return projectCommentsViewModel;
        }

        public async Task CreateCommentdAsync(ProjectComment request)
        {
            await _dbContext.ProjectComments.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateProjectAsync(Project request)
        {
            await _dbContext.Projects.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
