using CadastroPessoa.API.Configuracao;


var builder = WebApplication.CreateBuilder(args);


builder.ConfigAmbiente();

IConfiguration configuration = builder.Configuration;
builder.Services.AddApiConfiguration(configuration);
builder.Services.RegisterServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
var app = builder.Build();
app.UseApiConfiguration(app);
app.Run();