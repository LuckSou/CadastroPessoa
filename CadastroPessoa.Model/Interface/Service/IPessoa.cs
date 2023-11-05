using CadastroPessoa.Model.Model;

namespace CadastroPessoa.Model.Interface.Service
{
    public interface IPessoa
    {
        Task<IEnumerable<Pessoa>> ConsultarTodasPessoasAsync();
        Task<Pessoa> ConsultarPessoaPorCodigoAsync(int codigo);
        Task<IEnumerable<Pessoa>> ConsultarPessoasPorUFAsync(string uf);
        Task<Pessoa> GravarPessoaAsync(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoaAsync(int codigo, Pessoa pessoa);
        Task<bool> ExcluirPessoaAsync(int codigo);
    }
}
