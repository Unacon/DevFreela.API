using Azure.Core;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }        

        public async Task<User> GetUserAsync(int id)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

            if (user == null) return null;
            return new User(user.FullName, user.Email, user.BithDate, user.Password, user.Role);
        }

        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateSkillAsync(UserSkill request)
        {
            await _dbContext.UserSkill.AddAsync(request);
        }

        public async Task CreateUserAsync(User request)
        {
            await _dbContext.Users.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSkillAsync(UserSkill request)
        {
            _dbContext.UserSkill.Remove(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserSkill> GetSkillAsync(int idUser, int idSkill)
        {
            UserSkill userSkill =  await _dbContext.UserSkill.FirstOrDefaultAsync(u => u.IdSkill == idSkill && u.IdUser == idUser);

            return userSkill;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .Users
                .SingleOrDefaultAsync(item => item.Email == email && item.Password == passwordHash);
        }
    }
}
