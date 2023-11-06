using CadastroPessoa.Model.Interface.Data;
using CadastroPessoa.Model.Interface.Service;
using CadastroPessoa.Model.Model;
using CadastroPessoa.Service.Util;

namespace CadastroPessoa.Service.Controll
{
    public class PessoaControll : IPessoa
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaControll(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<Pessoa>> ConsultarTodasPessoasAsync()
        {
            return await _pessoaRepository.ConsultarTodasPessoasAsync();
        }

        public async Task<Pessoa> ConsultarPessoaPorCodigoAsync(int codigo)
        {
            return await _pessoaRepository.ConsultarPessoaPorCodigoAsync(codigo);
        }

        public async Task<IEnumerable<Pessoa>> ConsultarPessoasPorUFAsync(string uf)
        {
            return await _pessoaRepository.ConsultarPessoasPorUFAsync(uf.ToUpper());
        }

        public async Task<Pessoa> GravarPessoaAsync(Pessoa pessoa)
        {
            pessoa.UF = pessoa.UF?.ToUpper();
            var pessoaValidacao = new PessoaValidacao();
            var errosValidacao = pessoaValidacao.ValidarPessoa(pessoa);

            if (errosValidacao.Count > 0)
            {
                var erroResponse = new RespostaErroValidacao();
                erroResponse.Erros.AddRange(errosValidacao);

                throw new ValidacaoException("Erro de validação: " + string.Join(", ", errosValidacao));
            }

            var pessoaGravada = await _pessoaRepository.GravarPessoaAsync(pessoa);
            return pessoaGravada;
        }

        public async Task<Pessoa> AtualizarPessoaAsync(int codigo, Pessoa pessoa)
        {
            pessoa.UF = pessoa.UF?.ToUpper();

            var pessoaValidacao = new PessoaValidacao();
            var errosValidacao = pessoaValidacao.ValidarPessoa(pessoa);

            if (errosValidacao.Count > 0)
            {
                var erroResponse = new RespostaErroValidacao();
                erroResponse.Erros.AddRange(errosValidacao);

                throw new ValidacaoException("Erro de validação: " + string.Join(", ", errosValidacao));
            }

            var pessoaAtualizada = await _pessoaRepository.AtualizarPessoaAsync(codigo, pessoa);
            return pessoaAtualizada;
        }

        public async Task<bool> ExcluirPessoaAsync(int codigo)
        {
            return await _pessoaRepository.ExcluirPessoaAsync(codigo);
        }
    }
}
