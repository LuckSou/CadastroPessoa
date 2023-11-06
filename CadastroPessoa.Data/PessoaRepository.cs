using CadastroPessoa.Model.Interface.Data;
using CadastroPessoa.Model.Model;
using CadastroPessoa.Service.Util;

namespace CadastroPessoa.Data
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly List<Pessoa> _pessoas;
        private int _nextCodigo;

        public PessoaRepository()
        {
            _pessoas = new List<Pessoa>();
            _nextCodigo = 1;
        }

        public async Task<IEnumerable<Pessoa>> ConsultarTodasPessoasAsync()
        {
            return _pessoas;
        }

        public async Task<Pessoa> ConsultarPessoaPorCodigoAsync(int codigo)
        {
            return _pessoas.FirstOrDefault(p => p.Codigo == codigo);
        }

        public async Task<IEnumerable<Pessoa>> ConsultarPessoasPorUFAsync(string uf)
        {
            return _pessoas.Where(p => p.UF == uf).ToList();
        }

        public async Task<Pessoa> GravarPessoaAsync(Pessoa pessoa)
        {

            pessoa.Codigo = _nextCodigo++;

            if (VerificarCPFDuplicado(pessoa.Codigo, pessoa.CPF))
            {
                throw new ValidacaoException("O CPF já está registrado.");
            }
            _pessoas.Add(pessoa);
            return pessoa;
        }

        public async Task<Pessoa> AtualizarPessoaAsync(int codigo, Pessoa pessoa)
        {
            var pessoaExistente = _pessoas.FirstOrDefault(p => p.Codigo == codigo);


            if (VerificarCPFDuplicado(pessoaExistente.Codigo, pessoa.CPF))
            {
                throw new ValidacaoException("O CPF já está registrado.");
            }

            if (pessoaExistente != null)
            {

                pessoaExistente.Nome = pessoa.Nome;
                pessoaExistente.CPF = pessoa.CPF;
                pessoaExistente.UF = pessoa.UF;
                pessoaExistente.DataNascimento = pessoa.DataNascimento;
                return pessoaExistente;
            }

            return null;
        }

        public async Task<bool> ExcluirPessoaAsync(int codigo)
        {
            var pessoaExistente = _pessoas.FirstOrDefault(p => p.Codigo == codigo);

            if (pessoaExistente != null)
            {
                _pessoas.Remove(pessoaExistente);
                return true;
            }

            return false;
        }
        public bool VerificarCPFDuplicado(int codigo, string cpf)
        {
            return _pessoas.Any(p => p.CPF == cpf && p.Codigo != codigo);
        }
    }
}
