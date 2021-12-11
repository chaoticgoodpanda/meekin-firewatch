using System;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // allows anonymous (not logged in) access to endpoints in order for user to actually login :)
    [AllowAnonymous]
    // we don't use MediatR for this part of the app
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<User> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            // TODO: Maybe put in later logic to also login via email address (ternary likely w/ new var)
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null )
            {
                ModelState.AddModelError("email", "Email invalid.");
                return ValidationProblem(ModelState);
            }

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                ModelState.AddModelError("password", "Invalid password.");
                return ValidationProblem(ModelState);
            }

            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Organization = user.Organization,
                DisplayName = user.DisplayName,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                // manually add errors to model state to fix errors not a function error on client side
                ModelState.AddModelError("email", "Email already in use.");
                // need to use ValidationProblem in order to properly return the errors Object to work with client side
                return ValidationProblem(ModelState);
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                ModelState.AddModelError("username", "Username already taken.");
                return ValidationProblem(ModelState);
            }
            
            var user = new User
            {
                UserName = registerDto.Username, 
                Email = registerDto.Email, 
                Organization = registerDto.Organization,
                DisplayName = registerDto.DisplayName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }
            
            await _userManager.AddToRoleAsync(user, "Member");

            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Organization = user.Organization,
                DisplayName = user.DisplayName,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            // retrieves name from token
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return new UserDto
            {
                Email = user.Email,
                Username = user.UserName,
                Organization = user.Organization,
                DisplayName = user.DisplayName,
                Token = await _tokenService.GenerateToken(user)
            };
        }
    }
}