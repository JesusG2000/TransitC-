using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Filters;

namespace WebApplication2.Controllers
{
   
    [ApiController]
    public class UserRestController : ControllerBase 
    {
        private AppDbContext appDbContext; 
        public UserRestController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;   
        }
        [ServiceFilter(typeof(MyFilter))]
        [Route("api/users")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await appDbContext.Users.ToListAsync();
        }
        [ServiceFilter(typeof(MyFilter))]
        [Route("api/user")]
        [HttpPut]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!appDbContext.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            appDbContext.Update(user);
            await appDbContext.SaveChangesAsync();
            return Ok(user);
        } 
        [ServiceFilter(typeof(MyFilter))]
        [Route("api/user")]
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            User isExist = await appDbContext.Users.FirstOrDefaultAsync(u => u.Name == user.Name);
            if (isExist == null)
            {
                 return NotFound();
            }
            return Ok(isExist);
        }
        [ServiceFilter(typeof(MyFilter))]
        [Route("api/user/{id}")]
        [HttpDelete]

        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = appDbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            appDbContext.Users.Remove(user);
            await appDbContext.SaveChangesAsync();
            return Ok(user);
        }
        [Route("user/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login", "home");
        }
    }
}
