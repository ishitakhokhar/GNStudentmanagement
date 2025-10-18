using GNStudentManagement.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GNStudentManagement.Helpers
{
    public class JWTHelper
    {
        private static JWTModel _objJWTModel;

        public static void Initialize(JWTModel objJWTModel)
        {
            _objJWTModel = objJWTModel;
        }

        public object GenerateJWTToken(string email, int id, string role, int expirationHours = 1)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            if (id <= 0)
                throw new ArgumentException("ID must be a positive integer.", nameof(id));
            if (string.IsNullOrWhiteSpace(role))
                throw new ArgumentException("Role cannot be null or empty.", nameof(role));

            // Define the claims for the token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_objJWTModel.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            try
            {
                // Create the JWT token
                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _objJWTModel.Issuer,
                    audience: _objJWTModel.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(expirationHours),
                    signingCredentials: signingCredentials
                );

                // Serialize the token
                var tokenHandler = new JwtSecurityTokenHandler();
                string token = tokenHandler.WriteToken(jwtSecurityToken);

                return new { Token = token };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to generate JWT token.", ex);
            }
        }
    }
}