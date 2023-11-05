using CadastroPessoa.Data;
using CadastroPessoa.Model.Interface.Data;
using CadastroPessoa.Model.Interface.Service;
using CadastroPessoa.Service.Controll;

namespace CadastroPessoa.API.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<JsonValidationFilter>();
            services.AddScoped<IAutenticacao, AutenticacaoControll>();
            services.AddScoped<IPessoa, PessoaControll>();
            services.AddSingleton<IPessoaRepository, PessoaRepository>();
        }
    }
}
