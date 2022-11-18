using AutoMapper;
using MediatR;
using ProjetoPiloto.Cadastro.API.Models;
using ProjetoPiloto.Cadastro.Application;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.GetAuthorById;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.ListAuthor;
using ProjetoPiloto.Cadastro.Infraestrutura;
using ProjetoPiloto.Cadastro.Infraestrutura.ModelMap;
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



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


//Add Application Services
builder.Services.AddInfrastructureServices(builder.Configuration, typeof(AuthorMap).Assembly); //Need just one class from Infrastructure Assembly to pass. May be any.
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


#region Endpoints

app.MapGet("/authors/{page}/{size}", async (int page, int size, IMediator mediator, IMapper mapper) =>
{

    try
    {
        ListAuthorQuery query = new ListAuthorQuery(page, size);
        var result = await mediator.Send(query);

        return Results.Ok(mapper.Map<List<AuthorDTO>>(result));
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
        return Results.BadRequest(ex.Message);
    }

})
.WithName("ListAuthors");

app.MapPost("/authors", async (AuthorDTO authorDTO, IMediator mediator, IMapper mapper) =>
{
    try
    {
        var command = mapper.Map<AddAuthorCommand>(authorDTO);
        var result = await mediator.Send(command);

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
        return Results.BadRequest(ex.Message);
    }
})
.WithName("AddAuthor");


app.MapPut("/authors", async (AuthorDTO authorDTO, IMediator mediator, IMapper mapper) =>
{
    try
    {
        var command = mapper.Map<UpdateAuthorCommand>(authorDTO);
        var result = await mediator.Send(command);

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
        return Results.BadRequest(ex.Message);
    }
})
.WithName("UpdateAuthor");

app.MapGet("/authors/{Id}", async (long Id, IMediator mediator, IMapper mapper) =>
{
    try
    {
        var query = new GetAuthorByIdQuery(Id);
        var result = await mediator.Send(query);

        return Results.Ok(mapper.Map<AuthorDTO>(result));
    }
    catch (Exception ex)
    {
        logger.Error(ex.Message);
        return Results.BadRequest(ex.Message);
    }
})
.WithName("GetAuthorById");

#endregion

app.Run();

