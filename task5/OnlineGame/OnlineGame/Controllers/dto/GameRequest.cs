using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGame.Controllers.dto
{
    public class GameRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] GameTags { get; set; }
    }
}
