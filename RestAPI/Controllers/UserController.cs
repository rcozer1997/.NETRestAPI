using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.DTO.User;
using RestAPI.Models;
using RestAPI.Repositories;
using RestAPI.Repositories.Interfaces;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {   
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet("search_all")]
        public async Task<ActionResult<List<UserDTO>>> SearchAllUsers()
        {
            List<UserDTO> result = await _userRepository.SearchAllUsers();

            return Ok(result);
        }

        [HttpGet("search_by_id/{id}")]
        public async Task<ActionResult<List<UserDTO>>> SearchUserById(string id)
        {
            UserDTO result = await _userRepository.SearchUserById(id);

            return Ok(result);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> SignUp([FromBody] UserSignUpDTO user)
        {
            bool result = await _userRepository.AddUser(user);

            return result;
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<UserDTO>> Update([FromBody] UserUpdateDTO user, string id)
        {
            UserDTO result = await _userRepository.UpdateUser(user, id);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {   
            bool deleted = await _userRepository.DeleteUser(id);

            return Ok(deleted);
        }
    }
}
