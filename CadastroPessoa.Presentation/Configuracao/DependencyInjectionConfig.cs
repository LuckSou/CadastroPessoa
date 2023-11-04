using CadastroPessoa.Model.Interface.Service;
using CadastroPessoa.Service.Controll;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph.ExternalConnectors;

namespace CadastroPessoa.API.Configuracao
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAutenticacao, AutenticacaoControll>();
        }
    }
}
