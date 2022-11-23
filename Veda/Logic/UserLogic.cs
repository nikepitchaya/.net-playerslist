using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlayersList.Models.Entity;
using PlayersList.Models.Request;
using PlayersList.Models.Response;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PlayersList.Logic
{
    public class UserLogic
    {
        private readonly IConfiguration config;

        public UserLogic(IConfiguration config)
        {
            this.config = config;
        }
        public UserEntity MapNewUser(CreateUserRequest createUserRequest)
        {
            UserEntity newUser = new UserEntity()
            {
                username = createUserRequest.username,
                name = createUserRequest.name,
                password = createUserRequest.password,
                email = createUserRequest.email,
                created_at = DateTime.Now,
                updated_at = DateTime.Now
            };
            return newUser;
        }

        public UserResponse MapCreateUserResponse(UserEntity createUserResponse)
        {
            UserResponse userResponse = new UserResponse()
            {
                id = createUserResponse.id,
                username = createUserResponse.username,
                name = createUserResponse.name,
                email = createUserResponse.email
            };
            return userResponse;
        }

        public string GenerateToken(UserResponse userResponse)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new []
            {
             new Claim(ClaimTypes.NameIdentifier,userResponse.id.ToString()),
             new Claim(ClaimTypes.Name,userResponse.username),
             new Claim(ClaimTypes.GivenName,userResponse.name),
             new Claim(ClaimTypes.Email, userResponse.email),
            };
            
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
