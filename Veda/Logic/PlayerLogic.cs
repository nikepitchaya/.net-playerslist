using Microsoft.Extensions.Configuration;
using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using System;
using System.Collections.Generic;

namespace PlayersList.Logic
{
    public class PlayerLogic
    {
        private readonly IConfiguration config;

        public PlayerLogic(IConfiguration config)
        {
            this.config = config;
        }

        public PlayerEntity MapNewPlayer(CreatePlayerRequest createPlayerRequest)
        {
            PlayerEntity newPlayer = new PlayerEntity()
            {
                user_game_category_id = createPlayerRequest.user_game_category_id,
                type_id= createPlayerRequest.type_id,
                name = createPlayerRequest.name,
                about = createPlayerRequest.about,
                action= createPlayerRequest.action,
                created_at = DateTime.Now,
                updated_at = DateTime.Now

            };
            return newPlayer;
        }

        
        public PlayerResponse MapPlayerResponse(PlayerEntity player)
        {
            PlayerResponse newPlayer = new PlayerResponse()
            {
                id = player.id,
                user_game_category_id = player.user_game_category_id,
                type_id = player.type_id,
                name = player.name,
                about = player.about,
                action = player.action,
                updated_at = player.updated_at,
            };
            return newPlayer;
        }

        public List<PlayerResponse> MapPlayerListResponse(List<PlayerEntity> player)
        {
            List<PlayerResponse> playerList = new List<PlayerResponse>();
             foreach (PlayerEntity item in player)
            {
                PlayerResponse player1 = new PlayerResponse()
                {
                    id = item.id,
                    user_game_category_id = item.user_game_category_id,
                    type_id = item.type_id,
                    name = item.name,
                    about = item.about,
                    action = item.action,
                    updated_at = item.updated_at,
                };
                    playerList.Add(player1);
            };
            return playerList;
        }
    }
}
