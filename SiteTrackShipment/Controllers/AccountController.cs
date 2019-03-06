using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Date.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SiteTrackShipment.ViewModels;

namespace SiteTrackShipment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpPost("/token")]
        public async Task Token()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];

            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;
            
            var jwt = new JwtSecurityToken(
                    issuer: AuthOption.ISSUER,
                    audience: AuthOption.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOption.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            // сериализация ответа
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private ClaimsIdentity GetIdentity(string email, string password)
        {
            //User person = User.FirstOrDefault(x => x.Login == email && x.Password == password);
            //if (person != null)
            //{
            //    var claims = new List<Claim>
            //    {
            //        new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
            //        new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Password)
            //    };
            //    ClaimsIdentity claimsIdentity =
            //    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            //        ClaimsIdentity.DefaultRoleClaimType);
            //    return claimsIdentity;
            //}

            // если пользователя не найдено
            return null;
        }
    }
}