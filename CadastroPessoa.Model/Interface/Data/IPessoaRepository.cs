using CadastroPessoa.Model.Model;

namespace CadastroPessoa.Model.Interface.Data
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> ConsultarTodasPessoasAsync();
        Task<Pessoa> ConsultarPessoaPorCodigoAsync(int codigo);
        Task<IEnumerable<Pessoa>> ConsultarPessoasPorUFAsync(string uf);
        Task<Pessoa> GravarPessoaAsync(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoaAsync(int codigo, Pessoa pessoa);
        Task<bool> ExcluirPessoaAsync(int codigo);
        bool VerificarCPFDuplicado(int codigo, string cpf);
    }
}
