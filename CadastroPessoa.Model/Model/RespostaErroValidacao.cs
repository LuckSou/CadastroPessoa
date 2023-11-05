namespace CadastroPessoa.Model.Model
{
    public class RespostaErroValidacao
    {
        public List<string> Erros { get; set; }

        public RespostaErroValidacao()
        {
            Erros = new List<string>();
        }
    }
}
