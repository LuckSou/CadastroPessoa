using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPessoa.Model.Model
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string TokenType { get; set; }
        public long ExpiresIn { get; set; }
    }
}
