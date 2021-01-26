using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.dto
{
    public class UserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ImgPath { get; set; }
    }
}
