using MyTask.Models.Entity;
using PlayersList.Models.Entity;
using System.Collections.Generic;

namespace PlayersList.Service.Game
{
    public interface IGameService
    {
        List<GameCategoryEntity> GetAllGameCategory();

        GameCategoryEntity GetGameCategoryById(int gameCategoryId);

        List<GameCategoryEntity> GetGameCategoryByUserId(int userId);

        List<UserGameCategoryEntity> GetUserGameCategoryIdByUserId(int userId);

        string UserAddGameCategory(UserGameCategoryEntity newUserAddGameCategory);
    }
}
