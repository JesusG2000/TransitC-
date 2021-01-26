using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.dto
{
    public class ServerResponce
    {
        public ServerResponce(string status)
        {
            Status = status;
        }

        public string Status { get; set; }
    }
}
