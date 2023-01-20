using AutoMapper;
using MediatR;
using ProjetoPiloto.Cadastro.Application;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.GetAuthorById;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.ListAuthor;
using ProjetoPiloto.Cadastro.Infraestrutura;
using ProjetoPiloto.Cadastro.Infraestrutura.ModelMap;
using ProjetoPiloto.Utils.Extensions;
using ProjetoPiloto.Utils.Extensions.Modules;
using ProjetoPiloto.Utils.Vault;
using Serilog;
using System.Net.Sockets;
using System.Reflection;
using VaultSharp.V1.SecretsEngines.Database;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();

var config = builder.Configuration;
var host = builder.Host;

//Registrer Keycloack Authrization
builder.Services.RegisterKeycloakAuthentication(host, config);

config.AddJsonFile("appsettings.json");
config.AddEnvironmentVariables(prefix: "VAULT_");


builder.Services.RegisterModules(Assembly.GetExecutingAssembly(), config);



var app = builder.Build();

if (config.GetSection("Vault")["Role"] != null)
{
    config.AddVault(options =>
    {
        var vaultOptions = config.GetSection("Vault");
        options.Address = vaultOptions["Address"];
        options.Role = vaultOptions["Role"];
        options.MountPath = vaultOptions["MountPath"];
        options.SecretType = vaultOptions["SecretType"];
        options.Secret = config.GetSection("VAULT_SECRET_ID").Value;

    });
}


app.MapEndpoints(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication()
    .UseAuthorization();

app.UseHttpsRedirection();

app.Run();

