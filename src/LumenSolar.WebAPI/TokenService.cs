using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace LumenSolar.WebAPI
{
    public class TokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public TokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GerarToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new();

            List<Claim> claims = new() { new Claim(ClaimTypes.NameIdentifier, user.Id) };

            foreach (string role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789")),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
