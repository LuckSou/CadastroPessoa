using CadastroPessoa.Model.Model;
using CadastroPessoa.Service.Util;

namespace CadastroPessoa.Test
{
    public class PessoaValidacaoTests
    {
        [Fact]
        public void ValidarPessoa_DeveRetornarErrosParaPessoaInvalida()
        {
            // Arrange
            var pessoaValidacao = new PessoaValidacao();
            var pessoa = new Pessoa { Nome = "", CPF = "12345", UF = "ZZ", DataNascimento = DateTime.Now.AddYears(1) };

            // Act
            var errors = pessoaValidacao.ValidarPessoa(pessoa);

            // Assert
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void ValidarPessoa_DeveRetornarVazioParaPessoaValida()
        {
            // Arrange
            var pessoaValidacao = new PessoaValidacao();
            var pessoa = new Pessoa { Nome = "Nome", CPF = "12345678909", UF = "SP", DataNascimento = DateTime.Now.AddYears(-30) };

            // Act
            var errors = pessoaValidacao.ValidarPessoa(pessoa);

            // Assert
            Assert.Empty(errors);
        }
    }
}