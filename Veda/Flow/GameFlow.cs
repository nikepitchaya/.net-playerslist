using MyTask.BusinessLogic.CreateTaskBusinestLogic;
using MyTask.Models.Entity;
using MyTask.Models.Response;
using MyTask.Service.Color;
using MyTask.Service.Task;
using PlayersList.Logic;
using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using PlayersList.Service.Game;
using System.Collections.Generic;

namespace PlayersList.Flow
{
    public class GameFlow
    {
        private readonly IGameService gameService;
        private readonly GameLogic gameLogic;
        public GameFlow(IGameService gameService, GameLogic gameLogic) 
        { 
            this.gameService = gameService;
            this.gameLogic = gameLogic; 
        }
        public string UserAddGameCategory(int userId,UserAddGameCategoryRequest userAddGameCategoryRequest)
        {
            string response = "";
            GameCategoryEntity gameCategory = gameService.GetGameCategoryById(userAddGameCategoryRequest.game_category_id);
            if(gameCategory != null)
            {
                UserGameCategoryEntity newUserAddGameCategory = gameLogic.MapNewUserAddGameCategory(userId,gameCategory.id);
                response = gameService.UserAddGameCategory(newUserAddGameCategory);
            }
            return response;
        }   
        
        public List<GameCategoryResponse> GetAllGameCategory()
        {
            List<GameCategoryResponse> gameCategoryResponses = new List<GameCategoryResponse>();
            List<GameCategoryEntity> gameCategory = gameService.GetAllGameCategory();
            if(gameCategory != null)
            {
                gameCategoryResponses = gameLogic.MapGameCategoryResponse(gameCategory);
            }
            return gameCategoryResponses;
        }
        public List<UserGameCategoryResponse> GetGameCategoryByUserId(int userId)
        {
            List<UserGameCategoryResponse> userGameCategoryResponses = new List<UserGameCategoryResponse>();
            List<GameCategoryResponse> gameCategoryResponses = new List<GameCategoryResponse>();
            List<GameCategoryEntity> gameCategory = gameService.GetGameCategoryByUserId(userId);
            if (gameCategory != null)
            {
                gameCategoryResponses = gameLogic.MapGameCategoryResponse(gameCategory);
            }
            List<UserGameCategoryEntity> userGameCategory = gameService.GetUserGameCategoryIdByUserId(userId);
            if (gameCategoryResponses != null && userGameCategory != null)
            {
                userGameCategoryResponses = gameLogic.MapUserGameCategoryResponse(userGameCategory, gameCategoryResponses);
            }
            return userGameCategoryResponses;
        }

    }
}
