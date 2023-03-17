using PlayersList.Models.Entity;
using System.Collections.Generic;

namespace PlayersList.Service.Player
{
    public interface IPlayerService
    {
        PlayerEntity CreatePlayer(PlayerEntity newPlayer);

        List<PlayerEntity> GetAllPlayerByUserGameCategoryId(long userGameCategoryId);

        PlayerEntity DeletePlayerByPlayerId(long playerId);
    }
}
