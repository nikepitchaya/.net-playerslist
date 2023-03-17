using Microsoft.AspNetCore.Mvc;
using PlayersList.Flow;
using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PlayersList.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly PlayerFlow playerFlow;

        // For avoid exception null
        public PlayerController(PlayerFlow playerFlow)
        {
            this.playerFlow = playerFlow;
        }


        [HttpPost("api/v1/create_player")]
        public PlayerResponse CreateNewPlayer([FromBody] CreatePlayerRequest createPlayerRequest)
        {
            int userId = GetUserIdAuthorization();
            return playerFlow.CreateNewPlayer(userId, createPlayerRequest);
        }

        [HttpGet("api/v1/getallplayer")]
        public List<PlayerResponse> GetPlayerByUserGameCategoryId([FromQuery] long userGameCategoryId)
        {
            int userId = GetUserIdAuthorization();
            return playerFlow.GetPlayerByUserGameCategoryId(userGameCategoryId);
        }

        [HttpDelete("api/v1/delete_player")]
        public PlayerEntity DeletePlayer([FromQuery] long playerId)
        {
            int userId = GetUserIdAuthorization();
            return playerFlow.DeletePlayer(playerId);
        }

    }
}
