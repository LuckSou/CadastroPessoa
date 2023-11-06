using CadastroPessoa.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastroPessoa.Model.Model
{
    public class Pessoa
    {
        [JsonIgnore]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'CPF' é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve ter 11 números.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'UF' é obrigatório.")]
        [StringLength(2, ErrorMessage = "UF deve ter 2 letras.")]
        public string UF { get; set; }

        [DataType(DataType.Date)]

        [Required(ErrorMessage = "O campo 'DataNascimento' é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
