using CadastroPessoa.Model.Interface.Service;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CadastroPessoa.Model.Model;

namespace CadastroPessoa.Service.Controll
{
    public class AutenticacaoControll : IAutenticacao
    {

        public bool ValidarCredenciais(string username, string password)
        {
            return username == "usuario" && password == "senha";
        }

        public TokenResponse GerarToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("sua_chave_secreta");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var expiresIn = (long)((TimeSpan)(tokenDescriptor.Expires - DateTime.UtcNow)).TotalMilliseconds;

            var tokenResponse = new TokenResponse
            {
                Token = tokenString,
                TokenType = "Bearer",
                ExpiresIn = expiresIn
            };

            return tokenResponse;
        }

    }
}
