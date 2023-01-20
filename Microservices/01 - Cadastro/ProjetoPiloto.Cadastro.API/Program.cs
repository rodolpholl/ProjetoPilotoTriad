using AutoMapper;
using MediatR;
using ProjetoPiloto.Cadastro.Application;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.GetAuthorById;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.ListAuthor;
using ProjetoPiloto.Cadastro.Infraestrutura;
using ProjetoPiloto.Cadastro.Infraestrutura.ModelMap;
using ProjetoPiloto.Utils.Extensions.Modules;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();



builder.Services.RegisterModules(Assembly.GetExecutingAssembly(),builder.Configuration);

var app = builder.Build();

app.MapEndpoints(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();

