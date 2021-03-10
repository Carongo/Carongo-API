using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Comum.Utils
{
    public static class JWT
    {
        public static string Gerar(string nome, string email, Guid id, int minutos)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Carongo-b71e507ae8f44b4396530166279942af"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("nome", nome),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, id.ToString())
            };

            var token = new JwtSecurityToken
                (
                    "Carongo",
                    "Carongo",
                    claims,
                    expires: DateTime.Now.AddMinutes(minutos),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}