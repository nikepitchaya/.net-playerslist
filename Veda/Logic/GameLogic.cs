
using Microsoft.VisualBasic;
using MyTask.Models.Response;
using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace PlayersList.Logic
{
    public class GameLogic
    {
        public List<GameCategoryResponse> MapGameCategoryResponse(List<GameCategoryEntity> allGame)
        {
            List<GameCategoryResponse> gameCategoryResponse = new List<GameCategoryResponse>();
            foreach (GameCategoryEntity item in allGame)
            {
                GameCategoryResponse game = new GameCategoryResponse()
                {
                    id = item.id, 
                    name = item.name,
                    about= item.about,
                    information= item.information,
                    system_requirement= item.system_requirement,
                    url_picture= item.url_picture,
                    url_video= item.url_video,
                };
                gameCategoryResponse.Add(game);
            };
            return gameCategoryResponse;
        }

        public List<UserGameCategoryResponse> MapUserGameCategoryResponse(List<UserGameCategoryEntity> userGameCategory , List<GameCategoryResponse> gameCategory)
        {
            List<UserGameCategoryResponse> gameCategoryResponse = new List<UserGameCategoryResponse>();
            for(int i = 0; i < userGameCategory.Count; i++)
            {
                if(userGameCategory[i].game_category_id == gameCategory[i].id)
                {
                    UserGameCategoryResponse data = new UserGameCategoryResponse()
                    {
                        id = (int)userGameCategory[i].id,  
                        updated_at = userGameCategory[i].updated_at,
                        gameCategory = gameCategory[i],
                    };
                    gameCategoryResponse.Add(data);
                }
            }
            return gameCategoryResponse;
        }

        public UserGameCategoryEntity MapNewUserAddGameCategory(int userId, int gameCategoryId)
        {
            UserGameCategoryEntity newUserAddGameCategory = new UserGameCategoryEntity()
            {
                user_id = userId,
                game_category_id = gameCategoryId,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };
            return newUserAddGameCategory;
        }
    }
}
