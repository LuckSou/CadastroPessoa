using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.Model.Model
{
    public class PessoaResultado
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string UF { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
