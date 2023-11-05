using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastroPessoa.Model.Model
{
    public class Pessoa
    {
        [JsonIgnore]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string UF { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
