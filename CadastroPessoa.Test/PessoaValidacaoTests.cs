using CadastroPessoa.Model.Model;
using CadastroPessoa.Service.Util;

namespace CadastroPessoa.Test
{
    public class PessoaValidacaoTests
    {
        [Fact]
        public void ValidarPessoa_DeveRetornarErrosParaPessoaInvalida()
        {
            var pessoaValidacao = new PessoaValidacao();
            var pessoa = new Pessoa { Nome = "", CPF = "12345", UF = "ZZ", DataNascimento = DateTime.Now.AddYears(1) };

            var errors = pessoaValidacao.ValidarPessoa(pessoa);

            Assert.NotEmpty(errors);
        }

        [Fact]
        public void ValidarPessoa_DeveRetornarVazioParaPessoaValida()
        {
            var pessoaValidacao = new PessoaValidacao();
            var pessoa = new Pessoa { Nome = "Nome", CPF = "12345678909", UF = "SP", DataNascimento = DateTime.Now.AddYears(-30) };

            var errors = pessoaValidacao.ValidarPessoa(pessoa);

            Assert.Empty(errors);
        }
    }
}