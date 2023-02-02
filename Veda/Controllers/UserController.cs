using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mytask.Controllers;
using PlayersList.Flow;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using System.IdentityModel.Tokens.Jwt;

namespace PlayersList.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserFlow  userFlow;

        // For avoid exception null
        public UserController(UserFlow userFlow)
        {
            this.userFlow = userFlow;
        }

        [AllowAnonymous]
        [HttpPost("api/v1/register")]
        public UserResponse CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            return userFlow.CreateUser(createUserRequest);
        }

        [AllowAnonymous]
        [HttpPost("api/v1/login")]
        public string UserLogin([FromBody] UserLoginRequest userLoginRequest)
        {
            return userFlow.UserLogin(userLoginRequest);
        }

        [HttpGet("api/v1/me")]
        public UserResponse GetUser()
        {
            int userId = GetUserIdAuthorization();
            return userFlow.GetUser(userId);
        }

    }
}
