using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private async Task<bool> UserExists(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return true;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);

            if (user == null) return Unauthorized("Invalid username");

            return new UserDto
            {
                Email = user.Email,
                Name = user.Name,
                Role = user.Role
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(CreateUserDto createUserDto)
        {
            var userObj = await _userRepository.GetUserByEmail(createUserDto.Email);
            if (userObj != null && userObj.Email == createUserDto.Email)
            {
                return BadRequest("Email already exist.");
            }
            var result = await _userRepository.CreateUser(createUserDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetUsers());
        }
    }
}
