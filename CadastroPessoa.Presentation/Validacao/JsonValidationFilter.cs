using CadastroPessoa.Model.Model;
using Microsoft.AspNetCore.Mvc.Filters;

public class JsonValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ActionArguments.ContainsKey("pessoa"))
        {
            var pessoa = context.ActionArguments["pessoa"] as Pessoa;

            if (pessoa != null)
            {
                if (string.IsNullOrEmpty(pessoa.CPF) || !IsNumeric(pessoa.CPF) || pessoa.CPF.Length != 11)
                {
                    context.ModelState.AddModelError("pessoa.CPF", "CPF deve ter 11 números!");
                }

                if (string.IsNullOrEmpty(pessoa.UF) || pessoa.UF.Length != 2)
                {
                    context.ModelState.AddModelError("pessoa.UF", "UF deve ter 2 letras!");
                }

            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    private bool IsNumeric(string value)
    {
        return long.TryParse(value, out _);
    }
}
