using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Filters;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [ServiceFilter(typeof(MyFilter))]
        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult Login()  
        {
            return View();
        }
        public IActionResult Registration()  
        {
            return View();
        } 
    }
}
