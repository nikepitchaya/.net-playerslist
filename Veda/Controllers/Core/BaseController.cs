using Microsoft.AspNetCore.Mvc;
using PlayersList.ExceptionBase;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace PlayersList.Controllers
{
    public class BaseController : Controller
    {
        protected long GetUserId()
        {
            try
            {
                string user = Request.Headers["userId"];
                long userId = long.Parse(user);
                return userId;
            }
            catch
            {
                throw new ValidationException("กรุณาใส่ Headers userId");
            }
        }

        protected int GetUserIdAuthorization()
        {
            try
            {
                string jwt = Request.Headers["Authorization"];
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwt);
                string encodedUserId = token.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
                int userId = int.Parse(encodedUserId);
                return userId;
            }
            catch
            {
                throw new ValidationException("กรุณาใส่ Headers Authorization");
            }
        }

   
    }
}
