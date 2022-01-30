using System.Security.Claims;
using System.Threading.Tasks;
using GiBook.API.DTOs;
using GiBook.API.Models;
using GiBook.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiBook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly TokenService _tokenService;

        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            TokenService tokenService
        )
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized();

            var result =
                await _signInManager
                    .CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>>
        Register(RegisterDto registerDto)
        {
            if (
                await _userManager
                    .Users
                    .AnyAsync(x => x.Email == registerDto.Email)
            )
            {
                return BadRequest("Email taken");
            }

            if (
                await _userManager
                    .Users
                    .AnyAsync(x => x.UserName == registerDto.UserName)
            )
            {
                return BadRequest("User name taken");
            }

            var user =
                new AppUser {
                    Email = registerDto.Email,
                    //DisplayName = registerDto.DisplayName,
                    UserName = registerDto.UserName
                };

            var result =
                await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return BadRequest("failed regist");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user =
                await _userManager
                    .FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return CreateUserObject(user);
        }

        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto {
                Id = user.Id,
                Iamge = null,
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName,
                Email = user.Email
            };
        }
    }
}
