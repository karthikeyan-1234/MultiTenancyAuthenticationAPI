using DemoAuthenticationAPI.Models;

using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoAuthenticationAPI.Services
{
    public class TokenService : ITokenService
    {
        public TokenData GetToken(string userName)
        {
            string token = string.Empty;

            string group = userName == "Arjun" ? "US" : "Asia";

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim("Group",group)
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABCDEFGHIJKLMN09876654433hha;flahfdyahsfdhusaykhdsalfyodsahfdshlk"));

            var expires = DateTime.Now.AddSeconds(300);

            var jwttoken = new JwtSecurityToken(
                expires: expires,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenData = new TokenData { Token = new JwtSecurityTokenHandler().WriteToken(jwttoken), ExpiresAt = expires };

            return tokenData;
        }
    }
}
