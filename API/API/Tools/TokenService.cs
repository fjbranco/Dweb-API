using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Tools {

    /// <summary>
    /// 
    /// </summary>
    public class TokenService {
        private readonly IConfiguration _config;
        //
        public TokenService(IConfiguration config) {
            _config = config;
        }
        /// <summary>
        /// Método de geração de token JWT para um utilizador autenticado. O token inclui as seguintes claims:
        /// - Sub (Subject): ID do utilizador
        /// - Email: Email do utilizador
        /// - Jti (JWT ID): ID único do token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateToken(IdentityUser user) {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
           new Claim(JwtRegisteredClaimNames.Sub, user.Id),   // User ID
           new Claim(JwtRegisteredClaimNames.Email, user.Email),  // User Email - não será nulo pq é usado como UserName
           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
       };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(jwtSettings["ExpireHours"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
