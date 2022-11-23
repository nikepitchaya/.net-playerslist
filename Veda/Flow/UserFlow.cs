using PlayersList.Logic;
using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using PlayersList.Repository;
using PlayersList.Service.User;
using System.IdentityModel.Tokens.Jwt;

namespace PlayersList.Flow
{
    public class UserFlow
    {
        private readonly IUserService userService;
        private readonly UserLogic userLogic;
        
        public UserFlow(IUserService userService,UserLogic userLogic)
        {
            this.userService = userService;
            this.userLogic = userLogic;
        }
        public UserResponse CreateUser(CreateUserRequest createUserRequest)
        {
            try
            {
                UserResponse userResponse = new UserResponse();
                UserEntity newUser = userLogic.MapNewUser(createUserRequest);
                UserEntity createUserResponse = userService.CreateUser(newUser);
                if(createUserResponse != null) {
                    userResponse = userLogic.MapCreateUserResponse(createUserResponse);
                }
                return userResponse;
            }
            catch
            {
                throw;
            }
        }

        public string UserLogin(UserLoginRequest userLoginRequest)
        {
            try
            {
                UserResponse userResponse = new UserResponse();
                string token = "";
                UserEntity createUserResponse = userService.UserLogin(userLoginRequest.username,userLoginRequest.password);
                if(createUserResponse != null)
                {
                    userResponse = userLogic.MapCreateUserResponse(createUserResponse);
                    token = userLogic.GenerateToken(userResponse);
                }
                return token;
            }
            catch
            {
                throw;
            }
            
        }

        public UserResponse GetUser(int userId)
        {
            try
            {
                UserResponse userResponse = new UserResponse();
                UserEntity createUserResponse = userService.GetUser(userId);
                if (createUserResponse != null)
                {
                    userResponse = userLogic.MapCreateUserResponse(createUserResponse);
                }
                return userResponse;
            }
            catch
            {
                throw;
            }
        }
    }
}
