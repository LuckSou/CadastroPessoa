using CadastroPessoa.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.Model.Interface.Service
{
    public interface IAutenticacao
    {
        bool ValidarCredenciais(string username, string password);
        TokenResponse GerarToken(string username);
    }
}
