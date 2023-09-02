using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Models;
using RestAPI.Repositories.Interfaces;

namespace RestAPI.Repositories
{
    public class UserRepository : IUserRepository
     {  
        private readonly SystemDBContext _dbContext;
        public UserRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }
        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> SearchUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
           await _dbContext.Users.AddAsync(user);
           await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await SearchUserById(id);
            if(userById == null)
            {
                throw new Exception($"User with ID: {id} doesn't exist!");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Password = user.Password;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
                 
        }
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await SearchUserById(id);
            if (userById == null)
            {
                throw new Exception($"User with ID: {id} doesn't exist!");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
