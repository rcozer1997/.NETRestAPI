using RestAPI.DTO.User;
using RestAPI.Models;

namespace RestAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserDTO>> SearchAllUsers();
        Task<UserDTO> SearchUserById(string id);
        Task<bool> AddUser(UserSignUpDTO user);
        Task<UserDTO> UpdateUser(UserUpdateDTO user, string id);
        Task<bool> DeleteUser(string id);
    }
}
