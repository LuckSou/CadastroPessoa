using CadastroPessoa.Model.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAutenticacao autenticacao;

    public AuthController(IAutenticacao _autenticacao)
    {
        autenticacao = _autenticacao;
    }

    [HttpPost("token")]
    public IActionResult token(string authorization)
    {
        if (string.IsNullOrEmpty(authorization) || !authorization.StartsWith("Basic "))
        {
            return BadRequest("Credenciais de autorização inválidas.");
        }

        // Remove o prefixo "Basic " para obter a parte codificada em Base64.
        string base64Credentials = authorization.Substring("Basic ".Length).Trim();

        // Decodifique as credenciais Base64 para obter o username e password.
        string credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64Credentials));
        string[] parts = credentials.Split(':');
        if (parts.Length != 2)
        {
            return BadRequest("Credenciais inválidas.");
        }

        string username = parts[0];
        string password = parts[1];

        if (autenticacao.ValidarCredenciais(username, password))
        {
            var token = autenticacao.GerarToken(username);
            return Ok(new { token });
        }

        return Unauthorized();
    }


}
