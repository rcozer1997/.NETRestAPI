using RestAPI.DTO.User;

namespace RestAPI.Services
{
    public interface IAuthService
    {
        string GenerateTokenString(UserLoginDTO user);
        Task<bool> Login(UserLoginDTO user);
    }
}