using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers.dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{

    [ApiController]
    public class UploadController : ControllerBase
    {

        [HttpPost]
        [Route("upload")]
        public IActionResult Post()
        {
            return Ok(new ServerResponce("server"));
        }

    }

}
