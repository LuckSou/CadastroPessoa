namespace CadastroPessoa.Model.Interface.Service
{
    public interface IAutenticacao
    {
        bool ValidarCredenciais(string username, string password);
        Task<string> GerarTokenAsync(string username);
    }
}
