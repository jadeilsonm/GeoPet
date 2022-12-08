using GeoPetAPI.Shared.Constants;
using GeoPetAPI.Shared.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GeoPetAPI.Services
{
    public class TokenGenerator
    {
        public string Generate(CaregiverPeople people)
        {
            var tokenHandle = new JwtSecurityTokenHandler();

            var tokenDescript = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(people),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Defaults.KEY)),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Expires = DateTime.UtcNow.AddMinutes(Defaults.EXPIRATION_TIME)
            };
            var token = tokenHandle.CreateToken(tokenDescript);
            return tokenHandle.WriteToken(token);
        }

        public ClaimsIdentity AddClaims(CaregiverPeople people)
        {
            ClaimsIdentity claimsIdentity = new();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, people.Name));

            return claimsIdentity;
        }
    }
}
