using Library_Business.Dtos;
using Library_Business.Repository.Interfaces;
using Library_Data.Entities;
using Microsoft.AspNetCore.Identity;
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
            _userRepository= userRepository;
        }

        //[HttpPost("register")]
        //public async Task<ActionResult<User>> Register(RegisterDto registerDto)
        //{
        //    using var hmac = new HMACSHA512();//using for password salt

        //    var user = new User
        //    {
        //        Email = registerDto.Email,
        //        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //        PasswordSalt = hmac.Key
        //    };

        //    if (await UserExists(registerDto.Email)) return BadRequest("Username is taken");

        //    //var user = _mapper.Map<AppUser>(registerDto);
        //    //user.UserName = registerDto.Email.ToLower();

        //    //var result = await _userManager.CreateAsync(user, registerDto.Password);
        //    //if (!result.Succeeded) return BadRequest(result.Errors);

        //    //var roleResult = await _userManager.AddToRoleAsync(user, "Member");

        //    //if (!roleResult.Succeeded) return BadRequest(result.Errors);

        //    //return new UserDto
        //    //{
        //    //    Username = user.UserName,
        //    //    Token = await _tokenService.CreateToken(user),
        //    //    KnownAs = user.KnownAs,
        //    //    Gender = user.Gender
        //    //};
        //}

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
                Name= user.Name,
                Role = user.Role
            };         
        }
    }
}
