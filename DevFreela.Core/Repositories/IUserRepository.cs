using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task SaveChangeAsync();
        Task CreateSkillAsync(UserSkill request);
        Task CreateUserAsync(User request);

        Task DeleteSkillAsync(UserSkill request);

        Task<UserSkill> GetSkillAsync(int idUser, int idSkill);
    }
}
