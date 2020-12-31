using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }
    }
}
