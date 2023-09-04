using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.DTO.User;
using RestAPI.Models;
using RestAPI.Repositories.Interfaces;

namespace RestAPI.Repositories
{
    public class UserRepository : IUserRepository
     {  
        private readonly UserManager<UserModel> _userManager;
        private readonly SystemDBContext _dbContext;

        public UserRepository(SystemDBContext systemDBContext, UserManager<UserModel> userManager)
        {
            _dbContext = systemDBContext;
            _userManager = userManager;
        }
       
        public async Task<List<UserDTO>> SearchAllUsers()
        {
            List<UserModel> userModel = await _dbContext.Users.ToListAsync();
            return userModel.Select(x => new UserDTO()
            {
                Email = x.Email,
                Name = x.Name
            }).ToList();
        }

        public async Task<UserDTO> SearchUserById(string id)
        {
            UserModel userModel = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return new UserDTO()
            {
                Email = userModel.Email,
                Name = userModel.Name
            };
        } 

        public async Task<bool> AddUser(UserSignUpDTO user)
        {
                var identityUser = new UserModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.Email,
                };
                var result = await _userManager.CreateAsync(identityUser, user.Password);
                return result.Succeeded;      
        }

        public async Task<UserDTO> UpdateUser(UserUpdateDTO user, string id)
        {
            UserModel userById = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userById == null)
            {
                throw new Exception($"User with ID: {id} doesn't exist!");
            }
            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return new UserDTO()
            {
                Email = userById.Email,
                Name = userById.Name
            };

        }
        public async Task<bool> DeleteUser(string id)
        {
            UserModel userById = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
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
