using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers.dto;
using WebApplication1.Jwt;
using WebApplication1.Models;
using WebApplication1.Models.dto;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{

    [ApiController]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly IUserService userService;
        private readonly IUserRoleService userRoleService;

        public WeatherForecastController(IJwtAuthenticationManager jwtAuthenticationManager, IUserService userService, IUserRoleService userRoleService)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this.userService = userService;
            this.userRoleService = userRoleService;
        }
        [HttpGet("init")]
        public IActionResult Init()
        {
            if (userService.GetAll().Count == 0)
            {
                UserRole role = new UserRole();
                role.RoleType = RoleType.ADMIN;
                userRoleService.Create(role);
                role = new UserRole();
                role.RoleType = RoleType.USER;
                userRoleService.Create(role);

                User user = new User
                {
                    Login = "Admin",
                    Password = "Admin",
                    Block = false,
                    PathToImg = "v1611139359/unknown.jpg",
                    Role = userRoleService.ReadByRole(RoleType.ADMIN)
                };
                userService.Create(user);
            }
            return Ok();
        }
        [HttpPost("getUserByToken")]
        public IActionResult IsLoggedIn()
        {
            string headerValue = Request.Headers["Authorization"];
            string token = headerValue.Substring(7);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("jwt secret sentence");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                string accountName = jwtToken.Claims.First(x => x.Type == "unique_name").Value;
                User user = userService.GetByLogin(accountName);
                return Ok(user);
            }
            catch
            {
                return Unauthorized();
            }

        }
        [HttpPost("registration")]
        public IActionResult Register(UserRequest userRequest)
        {
            User user = new User();
            UserRole userRole = userRoleService.ReadByRole(RoleType.USER);
            user.Login = userRequest.Login;
            user.Password = userRequest.Password;
            user.PathToImg = userRequest.ImgPath;
            user.Block = false;
            user.Role = userRole;
            userService.Create(user);

            return Ok(user);
        }

        [HttpPost("isRegistered")]
        public IActionResult IsRegistered(RegisterUserRequest registerUserRequest)
        {
            User user = new User();
            user.Login = registerUserRequest.Login;
            if (userService.IsExist(user))
            {
                return Ok();
            }
            return NotFound();
        }
        // [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Auth(LoginUserRequest loginUserRequest)
        {
            User user = userService.GetByLoginAndPassword(loginUserRequest.Login, loginUserRequest.Password);
            if (user != null && !user.Block)
            {
                var token = jwtAuthenticationManager.Authenticate(user.Login, user.Password, user.Role.RoleString);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            else
            {
                return NotFound();
            }


        }
        /* [Authorize(Roles ="ROLE_ADMIN")]
        [HttpGet("AuthA")]
        public IActionResult AuthA()
        {
            int k = 0; 
            return Ok("hi admin");
        }
        [Authorize(Roles = "ROLE_USER")]
        [HttpGet("AuthU")]
        public IActionResult AuthU()
        {
            int k = 0; 
            return Ok("hi user");
        }*/
    }
}
