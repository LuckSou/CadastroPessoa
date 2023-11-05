using CadastroPessoa.Model.Model;

namespace CadastroPessoa.Service.Util
{
    public class PessoaValidacao
    {
        public List<string> ValidarPessoa(Pessoa pessoa)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                errors.Add("O campo 'Nome' é obrigatório.");
            }

            if (!ValidarCpf(pessoa.CPF))
            {
                errors.Add("O CPF informado é inválido.");
            }

            if (!ValidarUF(pessoa.UF))
            {
                errors.Add("A UF informada é inválida.");
            }

            if (pessoa.DataNascimento > DateTime.Now)
            {
                errors.Add("A data de nascimento não pode ser maior que a data atual.");
            }

            return errors;
        }

        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            {
                return false;
            }

            if (cpf.All(digit => digit == cpf[0]))
            {
                return false;
            }

            int[] digits = cpf.Select(digit => int.Parse(digit.ToString())).ToArray();

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += digits[i] * (10 - i);
            }
            int remainder = sum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;
            if (digits[9] != firstDigit)
            {
                return false;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += digits[i] * (11 - i);
            }
            remainder = sum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;
            if (digits[10] != secondDigit)
            {
                return false;
            }

            return true;
        }


        private bool ValidarUF(string uf)
        {
            string[] ufsValidas = { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

            return !string.IsNullOrWhiteSpace(uf) && ufsValidas.Contains(uf.ToUpper());
        }

    }
}
