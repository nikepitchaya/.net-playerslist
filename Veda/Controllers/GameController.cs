using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mytask.Controllers;
using PlayersList.Flow;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace PlayersList.Controllers
{
    public class GameController : BaseController
    {
        private readonly GameFlow gameFlow;

        // For avoid exception null
        public GameController(GameFlow gameFlow)
        {
            this.gameFlow = gameFlow;
        }

        [AllowAnonymous]
        [HttpGet("api/v1/allgamecategory")]
        public List<GameCategoryResponse> GetAllGameCategory()
        {
            return gameFlow.GetAllGameCategory();
        }

        [HttpPost("api/v1/addgamecategory")]
        public string UserAddGameCategory([FromBody] UserAddGameCategoryRequest userAddGameCategoryRequest)
        {
            int userId = GetUserIdAuthorization();
            return gameFlow.UserAddGameCategory(userId,userAddGameCategoryRequest);
        }

        [HttpGet("api/v1/mygamecategory")]
        public List<UserGameCategoryResponse> GetGameCategoryByUserId()
        {
            int userId = GetUserIdAuthorization();
            return gameFlow.GetGameCategoryByUserId(userId);
        }


    }
}
