using PlayersList.Logic;
using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using PlayersList.Service.Game;
using PlayersList.Service.Player;
using PlayersList.Service.User;
using System.Collections.Generic;

namespace PlayersList.Flow
{
    public class PlayerFlow
    {
        private readonly IPlayerService playerService;
        private readonly PlayerLogic playerLogic;
        public PlayerFlow(IPlayerService playerService, PlayerLogic playerLogic)
        {
            this.playerService = playerService;
            this.playerLogic = playerLogic;
        }

        public PlayerResponse CreateNewPlayer(int userId, CreatePlayerRequest createPlayerRequest)
        {
            try
            {
                PlayerResponse playerResponse = new PlayerResponse();
                PlayerEntity newPlayer = playerLogic.MapNewPlayer(createPlayerRequest);
                PlayerEntity createPlayerResponse = playerService.CreatePlayer(newPlayer);
                if (createPlayerResponse != null)
                {
                    playerResponse = playerLogic.MapPlayerResponse(createPlayerResponse);
                }
                return playerResponse;
            }
            catch
            {
                throw;
            }
        }

        public List<PlayerResponse> GetPlayerByUserGameCategoryId(long userGameCategoryId)
        {
            List<PlayerResponse> playerResponses = new List<PlayerResponse>();
            List<PlayerEntity> playerEntity = playerService.GetAllPlayerByUserGameCategoryId(userGameCategoryId);
            if (playerEntity != null)
            {
                playerResponses = playerLogic.MapPlayerListResponse(playerEntity);
            }
            return playerResponses;
        }

        public PlayerEntity DeletePlayer(long playerId)
        {
            PlayerEntity test = playerService.DeletePlayerByPlayerId(playerId);
            return test;
        }
    }


}
