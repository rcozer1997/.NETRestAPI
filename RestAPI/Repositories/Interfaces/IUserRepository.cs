using RestAPI.Models;

namespace RestAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> SearchAllUsers();
        Task<UserModel> SearchUserById(int id);
        Task<UserModel> AddUser(UserModel user);
        Task<UserModel> UpdateUser(UserModel user, int id);
        Task<bool> DeleteUser(int id);
    }
}
