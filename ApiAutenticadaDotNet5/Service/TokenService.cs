using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiAutenticadaDotNet5.Models;
using Microsoft.IdentityModel.Tokens;

namespace ApiAutenticadaDotNet5.Service
{
    public static class TokenService
    {
        public static string GenerateToken(User usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("qWn5!8C#gkGAih6mcaVDl27E!");
            // Aqui são as informações que vão ser passadas no token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Name.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Informa a sua chave para gerar
            };
            // Cria o token e escreve nele 
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}