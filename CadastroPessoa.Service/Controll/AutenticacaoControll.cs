using CadastroPessoa.Model.Interface.Service;
using CadastroPessoa.Model.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AutenticacaoControll : IAutenticacao
{
    private readonly IConfiguration _configuration;

    public AutenticacaoControll(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool ValidarCredenciais(string username, string password)
    {
        return username == "usuarioteste" && password == "senhasecreta";
    }

    public async Task<string> GerarTokenAsync(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var expiration = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JwtSettings:TokenDurationHours"]));

        var token = new JwtSecurityToken(issuer, audience, expires: expiration, signingCredentials: credentials);

        return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
    }

}
