using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private AppDbContext appDbContext;
        public RegisterController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [Route("register/regUser")]
        [HttpPost]
        public async Task<ActionResult<User>> regUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            appDbContext.Users.Add(user);
            await appDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [Route("register/isUserExist")]
        [HttpPost]
        public async Task<ActionResult<User>> IsUserExist(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            User isExist = await appDbContext.Users.FirstOrDefaultAsync(u => u.Name == user.Name);

            if (isExist == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
