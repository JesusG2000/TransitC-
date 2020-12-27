using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineGame.Controllers.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace OnlineGame.Controllers
{
    [ApiController]
    public class GameRestController : ControllerBase
    {
        //private AppDbContext appDbContext;
        //public GameRestController(AppDbContext appDbContext)
        //{
        //    this.appDbContext = appDbContext;
        //}
        private IHubContext<GameHub> hubContext;
        private static List<Game> games { get; }
        public GameRestController(IHubContext<GameHub> hubContext)
        {
            this.hubContext = hubContext;
        }
       

        static GameRestController()
        {
            games = new List<Game>();
        }

        [HttpPost]
        [Route("game/createCreator")]
        public async Task<ActionResult> CreateCreator(GameRequest gameRequest)
        {
            // Устанавливаем для сокета локальную конечную точку
            Game game = new Game();
            game.Id = gameRequest.Id;
            game.Name = gameRequest.Name;
            game.CountOfPlayers++;
            game.Tags=gameRequest.GameTags;
            game.finished=false;
            game.CreatorConnectionId = UserHandler.dictionary.FirstOrDefault(con => con.Value == gameRequest.Id).Key;
          //  UserHandler.dictionary.Remove(game.CreatorConnectionId);
            games.Add(game);

              
            MessageResponce messageResponce = new MessageResponce();
            messageResponce.Message = "game was created " + UserHandler.dictionary.Count;
            return Ok(game);
        }

        [HttpPost]
        [Route("game/connectPlayer/{gameId}")]
        public async Task<ActionResult> connectPlayer(int gameId)
        {


            Game game = games.First(game => game.Id == gameId);
            int index = games.IndexOf(game);
            game.PlayerConnectionId = UserHandler.dictionary.Where(con => con.Value == gameId).Skip(1).First().Key;
          //  UserHandler.dictionary.Remove(game.PlayerConnectionId);
            game.CountOfPlayers++;
            games[index] = game;

            MessageResponce messageResponce = new MessageResponce();
            messageResponce.Message = "client connected to game " + UserHandler.dictionary.Count;
            return Ok(game);
        }

        [HttpGet]
        [Route("game/getAll")]
        public async Task<ActionResult> getAll()
        {
            if (games.Count != 0)
            {
                List<GameResponce> responces = new List<GameResponce>();
                List<Game> notFinished = games.FindAll(game => !game.finished);
                notFinished.ForEach(game => responces.Add(new GameResponce(game.Id, game.Name , game.CountOfPlayers,game.Tags)));
                return Ok(responces);
            }
            else
            {
                MessageResponce messageResponce = new MessageResponce();
                messageResponce.Message = "No data";
                return BadRequest(messageResponce);
            }
        }

        [HttpGet]
        [Route("game/{gameId}")]
        public async Task<ActionResult> getGame(int gameId)
        {
            Game game = games.FirstOrDefault(game => game.Id == gameId);
            return Ok(game);
        }  
        
        [HttpGet]
        [Route("game/search/{gameTag}")]
        public async Task<ActionResult> getGamesByTag(string gameTag)
        {
            List<Game> gameList = games.FindAll(game => game.Tags.Any(tag => tag.Contains(gameTag)));
            if (gameList == null)
            {
                return BadRequest();
            }
            return Ok(gameList);
        } 
        
        [HttpPut]
        [Route("game/{gameId}")]
        public async Task<ActionResult> finishGame(int gameId)
        {
            Game game = games.FirstOrDefault(game => game.Id == gameId);
            if (game != null)
            { 
                int index = games.IndexOf(game);
                game.finished = true;
                games[index] = game;
            }
           
            return Ok();
        }

        [HttpGet]
        [Route("game/playerCountInGame/{gameId}")]
        public async Task<ActionResult> playerCountInGame(int gameId)
        {
            Game game = games.Find(game => game.Id == gameId);
            if (game == null)
            {
                return BadRequest();
            }
            return Ok(new CountResponce(game.CountOfPlayers));
        }
    }
}
