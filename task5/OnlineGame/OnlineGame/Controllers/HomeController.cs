using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGame.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Welcome(int gameId , string gameName,string[]gameTags)
        {
            return Game(gameId, gameName ,gameTags);
        }

        [HttpPost]
        public IActionResult Game(int gameId, string gameName, string[] gameTags)
        {

            ViewData["gameId"] = gameId;
            ViewData["gameName"] = gameName;
            ViewData["gameTags"] = gameTags;
            return View();
        }
    }
}
