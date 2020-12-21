using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
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
