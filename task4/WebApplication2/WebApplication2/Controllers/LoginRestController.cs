using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class LoginRestController : ControllerBase
    {
        private AppDbContext appDbContext;
        public LoginRestController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [Route("login/user")]
        [HttpPut]
        public async Task<ActionResult<User>> updateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
           
            appDbContext.Update(user);
            await appDbContext.SaveChangesAsync();
            return Ok(user);
        }
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
    };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
           
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

       

        [Route("login/isUserExist")]
        [HttpPost]
        public async Task<ActionResult<User>> isUserExistByLoginAndPassword(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            User isExist = await appDbContext.Users.FirstOrDefaultAsync(u => u.Name == user.Name && u.Password == user.Password);

            if (isExist == null)
            {
                return NotFound();
            }
            await Authenticate(isExist.Name); // аутентификация
            HttpContext.Response.Cookies.Append("user", isExist.Name);
            return Ok(isExist);
        }
    }
}
