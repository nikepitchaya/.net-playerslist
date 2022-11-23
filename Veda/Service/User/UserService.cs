using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Repository;

using PlayersList.ExceptionBase;

namespace PlayersList.Service.User
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository baseRepository;
        public UserService(IBaseRepository baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public UserEntity CreateUser(UserEntity newUser)
        {
            UserEntity createUserResponse = baseRepository.Create(newUser);
            return createUserResponse;
        }

        public UserEntity UserLogin(string username , string password)
        {
            UserEntity createUserResponse = baseRepository.GetItemInclude<UserEntity>(filter: a => a.username == username && a.password == password);
            if (createUserResponse == null)
            {
                throw new NotFoundException("This user doesn’t exits");
            }
            return createUserResponse;
        }

        public UserEntity GetUser(int userId)
        {
            UserEntity createUserResponse = baseRepository.GetItemInclude<UserEntity>(filter: a => a.id == userId);
            if (createUserResponse == null)
            {
                throw new NotFoundException("This user doesn’t exits");
            }
            return createUserResponse;
        }
    }
}
