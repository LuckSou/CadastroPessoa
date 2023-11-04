namespace CadastroPessoa.API.Configuracao
{
    public static class WebAppConfiguration
    {

        public static WebApplicationBuilder ConfigAmbiente(this WebApplicationBuilder web)
        {

            web.Configuration
                 .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{web.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            return web;

        }

    }
}
