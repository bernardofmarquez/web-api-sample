using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using WebApiSample.Model;

namespace WebApiSample.Service {
  public class TokenService {
    public static object GenerateToken(User user) {
      var key = Encoding.ASCII.GetBytes(JwtKey.Secret!);

      var tokenConfig = new SecurityTokenDescriptor {
        Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
          new Claim("userId", user.id!.ToString()),
        }),
        Expires = DateTime.UtcNow.AddHours(24),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenCreation = tokenHandler.CreateToken(tokenConfig);
      var token = tokenHandler.WriteToken(tokenCreation);
      

      return new { token };
    }
  }
}