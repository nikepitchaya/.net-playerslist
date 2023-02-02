
using MyTask.Models.Entity;
using PlayersList.Models.Entity;
using PlayersList.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PlayersList.Service.Game
{
    public class GameService : IGameService
    {
        private readonly IBaseRepository baseRepository;
        public GameService(IBaseRepository baseRepository) 
        { 
            this.baseRepository = baseRepository;
        }
        public List<GameCategoryEntity> GetAllGameCategory()
        {
            List<GameCategoryEntity> gameCategory = baseRepository.Gets<GameCategoryEntity>();
            return gameCategory;
        }
        public GameCategoryEntity GetGameCategoryById(int gameCategoryId)
        {
            GameCategoryEntity gameCategory = baseRepository.Gets<GameCategoryEntity>().FirstOrDefault(a => a.id == gameCategoryId);
            return gameCategory;
        }

        public List<GameCategoryEntity> GetGameCategoryByUserId(int userId)
        {
            List<int> gameCategoryIds = baseRepository.Gets<UserGameCategoryEntity>(filter: a => a.user_id == userId).Select( x => x.game_category_id).ToList();
            List<GameCategoryEntity> gameCategory = baseRepository.Gets<GameCategoryEntity>(a => gameCategoryIds.Contains(a.id)).ToList();
            return gameCategory;
        }

        public string UserAddGameCategory(UserGameCategoryEntity newUserAddGameCategory)
        {
            string response = "";
            UserGameCategoryEntity userGameCategory = baseRepository.Create(newUserAddGameCategory);
            if(userGameCategory != null)
            {
                response= "Successfully";
            }
            else
            {
                response = "Error";
            }
            return response;
        }
    }
}
