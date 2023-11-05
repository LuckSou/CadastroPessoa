using CadastroPessoa.Model.Interface.Service;
using CadastroPessoa.Model.Model;
using Microsoft.AspNetCore.Mvc;

[Route("api/auth")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAutenticacao _autenticacao;

    public TokenController(IConfiguration configuration, IAutenticacao autenticacao)
    {
        _configuration = configuration;
        _autenticacao = autenticacao;
    }

    [HttpPost("gerar-token")]
    public async Task<IActionResult> GerarTokenAsync([FromBody] Login model)
    {
        if (_autenticacao.ValidarCredenciais(model.Usuario, model.Senha))
        {
            var token = await _autenticacao.GerarTokenAsync(model.Usuario);
            return Ok(new { token });
        }

        return Unauthorized();
    }
}
