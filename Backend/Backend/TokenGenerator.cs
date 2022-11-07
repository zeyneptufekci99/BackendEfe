using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Application.Dtos;

namespace Backend
{
    public class TokenGenerator
    {
        public TokenResponse GenerateJwt(UserDto UserDto)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.Key));
            SigningCredentials credentials = new SigningCredentials
                (key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role,UserDto.RoleDefinition));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,UserDto.Id.ToString()));
            claims.Add(new Claim("Username", UserDto.Username));

            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtInfo.Issuer
                ,audience:JwtInfo.Audience,claims :claims, notBefore:DateTime.UtcNow, expires:DateTime.UtcNow.AddDays(15),signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponse( handler.WriteToken(token));
        }
       
    }
}
