using CadastroPessoa.API.Configuracao;
using CadastroPessoa.Model.Interface.Service;
using CadastroPessoa.Service.Controll;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;


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