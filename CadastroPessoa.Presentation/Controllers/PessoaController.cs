using CadastroPessoa.Model.Interface.Service;
using CadastroPessoa.Model.Model;
using CadastroPessoa.Service.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoa.API.Controllers
{
    [Route("api/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa _pessoa;

        public PessoaController(IPessoa pessoa)
        {
            _pessoa = pessoa;
        }

        [HttpGet("consultar-todas-as-pessoas")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PessoaResultado>))]
        public async Task<IActionResult> ConsultarTodasAsPessoas()
        {
            var pessoas = await _pessoa.ConsultarTodasPessoasAsync();
            var pessoasResultado = pessoas.Select(p => new PessoaResultado
            {
                Codigo = p.Codigo,
                Nome = p.Nome,
                CPF = p.CPF,
                UF = p.UF,
                DataNascimento = p.DataNascimento
            });
            return Ok(pessoasResultado);
        }

        [HttpGet("consultar-pessoa-por-codigo/{codigo}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaResultado))]
        public async Task<IActionResult> ConsultarPessoaPorCodigo(int codigo)
        {
            var pessoa = await _pessoa.ConsultarPessoaPorCodigoAsync(codigo);
            if (pessoa == null)
            {
                return NotFound();
            }
            var pessoaResultado = new PessoaResultado
            {
                Codigo = pessoa.Codigo,
                Nome = pessoa.Nome,
                CPF = pessoa.CPF,
                UF = pessoa.UF,
                DataNascimento = pessoa.DataNascimento
            };
            return Ok(pessoaResultado);
        }

        [HttpGet("consultar-pessoas-por-uf/{uf}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaResultado))]
        public async Task<IActionResult> ConsultarPessoasPorUF(string uf)
        {
            var pessoas = await _pessoa.ConsultarPessoasPorUFAsync(uf);
            var pessoasResultado = pessoas.Select(p => new PessoaResultado
            {
                Codigo = p.Codigo,
                Nome = p.Nome,
                CPF = p.CPF,
                UF = p.UF,
                DataNascimento = p.DataNascimento
            });
            return Ok(pessoasResultado);
        }

        [HttpPost("gravar-pessoa")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaResultado))]
        public async Task<IActionResult> GravarPessoa([FromBody] Pessoa pessoa)
        {
            try
            {
                var pessoaGravada = await _pessoa.GravarPessoaAsync(pessoa);
                var pessoaResultado = new PessoaResultado
                {
                    Codigo = pessoaGravada.Codigo,
                    Nome = pessoaGravada.Nome,
                    CPF = pessoaGravada.CPF,
                    UF = pessoaGravada.UF,
                    DataNascimento = pessoaGravada.DataNascimento
                };
                return CreatedAtAction("ConsultarPessoaPorCodigo", new { codigo = pessoaGravada.Codigo }, pessoaResultado);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar-pessoa/{codigo}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaResultado))]
        public async Task<IActionResult> AtualizarPessoa(int codigo, [FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return BadRequest("Dados da pessoa inválidos.");
                }

                var pessoaAtualizada = await _pessoa.AtualizarPessoaAsync(codigo, pessoa);

                if (pessoaAtualizada == null)
                {
                    return NotFound();
                }

                var pessoaResultado = new PessoaResultado
                {
                    Codigo = pessoaAtualizada.Codigo,
                    Nome = pessoaAtualizada.Nome,
                    CPF = pessoaAtualizada.CPF,
                    UF = pessoaAtualizada.UF,
                    DataNascimento = pessoaAtualizada.DataNascimento
                };
                return Ok(pessoaResultado);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("excluir-pessoa/{codigo}")]
        [Authorize]
        public async Task<IActionResult> ExcluirPessoa(int codigo)
        {
            var excluida = await _pessoa.ExcluirPessoaAsync(codigo);

            if (!excluida)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
