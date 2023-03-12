using Microsoft.AspNetCore.Mvc;
using PlayersList.Flow;
using System;

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


        [HttpGet("api/v1/create_player")]
        public string createPlayer()
        {
            int userId = GetUserIdAuthorization();
            return "";
        }

    }
}
