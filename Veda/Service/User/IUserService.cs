using PlayersList.Models.Entity;
using PlayersList.Models.Request;

namespace PlayersList.Service.User
{
    public interface IUserService
    {
        UserEntity UserLogin(string username , string password);
        UserEntity CreateUser(UserEntity newUser);
        UserEntity GetUser(int userId);
    }
}
