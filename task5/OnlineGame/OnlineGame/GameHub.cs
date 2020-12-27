using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace OnlineGame
{
    public static class UserHandler
    {
        public static Dictionary<string, int> dictionary = new Dictionary<string, int>();
        public static bool isCreatorMove = true;
    }
    public class GameHub : Hub
    {
       
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task Send(int gameId)
        {
             UserHandler.dictionary.Add(Context.ConnectionId , gameId);
            if(UserHandler.dictionary.Where(game => game.Value == gameId).Count() == 2)
            {
                await this.Clients.Client(UserHandler.dictionary.FirstOrDefault(game => game.Value == gameId).Key).SendAsync("Create", gameId);
            }
               
           
        }
        public async Task Move(Game game , int moveId)
        {
            if (
               (!UserHandler.isCreatorMove && game.PlayerConnectionId == Context.ConnectionId) ||
               (UserHandler.isCreatorMove && game.CreatorConnectionId == Context.ConnectionId)
               )
            {
                await this.Clients.Client(game.CreatorConnectionId).SendAsync("Update", true, moveId , UserHandler.isCreatorMove);
                await this.Clients.Client(game.PlayerConnectionId).SendAsync("Update" ,true, moveId, UserHandler.isCreatorMove);
                UserHandler.isCreatorMove=!UserHandler.isCreatorMove;
            }
            else
            {
                await this.Clients.Client(Context.ConnectionId).SendAsync("Update", false, moveId, UserHandler.isCreatorMove);
            }
            
        } 
        
      



    }
}
