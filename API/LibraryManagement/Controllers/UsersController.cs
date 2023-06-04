using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

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

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Id=user.Id,
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

            //using: to dispose the object when not in use.
            using var hmac = new HMACSHA512();//It will generate a random key that we will use as a SALT

            var user = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createUserDto.Password)),
                PasswordSalt = hmac.Key
            };

            var result = await _userRepository.CreateUser(user);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetUsers());
        }
    }
}
