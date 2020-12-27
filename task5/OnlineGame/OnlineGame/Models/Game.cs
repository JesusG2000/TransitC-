using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace WebApplication2.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorConnectionId { get; set; }
        public string PlayerConnectionId { get; set; }
        public string[] Tags { get; set; }
        public int CountOfPlayers { get; set; }
        public bool finished { get; set; }
        
    }
}
