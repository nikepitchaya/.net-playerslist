using PlayersList.Repository;

namespace PlayersList.Service.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly IBaseRepository baseRepository;
        public PlayerService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }


    }
}
