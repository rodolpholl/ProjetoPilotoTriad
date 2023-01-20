using AutoMapper;
using MediatR;
using ProjetoPiloto.Cadastro.API.Modules.Cadastro.Models;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor;


namespace ProjetoPiloto.Cadastro.API.Modules.Cadastro.Endpoints.Command
{
    public static class AddAuthor
    {
        public static IEndpointRouteBuilder MapAddAuthor(this IEndpointRouteBuilder endpoint, Serilog.ILogger logger)
        {
            endpoint.MapPost("/authors", async (AuthorModel authorModel, IMediator mediator, IMapper mapper) =>
            {
                try
                {
                    var command = mapper.Map<AddAuthorCommand>(authorModel);
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

            return endpoint;
        }
    }
}

