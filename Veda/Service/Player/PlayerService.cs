using PlayersList.Models.Entity;
using PlayersList.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PlayersList.Service.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly IBaseRepository baseRepository;
        public PlayerService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public PlayerEntity CreatePlayer(PlayerEntity newPlayer)
        {
            PlayerEntity createPlayerResponse = baseRepository.Create(newPlayer);
            return createPlayerResponse;
        }

        public List<PlayerEntity> GetAllPlayerByUserGameCategoryId(long userGameCategoryId)
        {
            List<PlayerEntity> createPlayerResponse = baseRepository.Gets<PlayerEntity>(filter: a => a.user_game_category_id == userGameCategoryId).ToList();
            return createPlayerResponse;

        }
        
        public PlayerEntity DeletePlayerByPlayerId(long playerId)
        {
            PlayerEntity player = baseRepository.Gets<PlayerEntity>().FirstOrDefault(a => a.id == playerId);
            PlayerEntity createDeletePlayerResponse = baseRepository.Delete<PlayerEntity>(player);
            return createDeletePlayerResponse;

        }
    }
}
