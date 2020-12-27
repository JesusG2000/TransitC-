using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGame.Controllers.dto
{
    public class GameResponce
    {
        public GameResponce(int id, string name, int countOfPlayers, string[] tags)
        {
            Id = id;
            Name = name;
            CountOfPlayers = countOfPlayers;
            Tags = tags;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfPlayers { get; set; }
        public string[] Tags { get; set; }
    }
}
