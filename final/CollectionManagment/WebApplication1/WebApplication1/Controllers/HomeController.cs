using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Welcome()
        {
            if (HttpContext.Request.Cookies["color"] == null)
            {
                ViewData["color"] = "/webix.trial.complete/webix/codebase/skins/contrast.css";
            }
            else
            {
                var c = HttpContext.Request.Cookies["color"];
                ViewData["color"] = HttpContext.Request.Cookies["color"];
            }
            return View();
        }
    }
}
