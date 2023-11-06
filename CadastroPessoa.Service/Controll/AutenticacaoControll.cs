using CadastroPessoa.Model.Interface.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
        var secretKey = _configuration["JwtSettings:SecretKey"];
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new InvalidOperationException("A chave secreta JWT não foi configurada.");
        }

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var expiration = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JwtSettings:TokenDurationHours"]));

        var token = new JwtSecurityToken(issuer, audience, expires: expiration, signingCredentials: credentials);

        return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
    }


}
