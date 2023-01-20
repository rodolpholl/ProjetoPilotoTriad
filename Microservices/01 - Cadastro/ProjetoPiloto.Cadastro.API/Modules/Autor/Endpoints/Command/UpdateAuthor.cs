using AutoMapper;
using MediatR;
using ProjetoPiloto.Cadastro.API.Modules.Cadastro.Models;
using ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor;

namespace ProjetoPiloto.Cadastro.API.Modules.Cadastro.Endpoints.Command
{
    public static class UpdateAuthor
    {
        public static IEndpointRouteBuilder MapUpdateAuthor(this IEndpointRouteBuilder endpoint, Serilog.ILogger logger)
        {
            endpoint.MapPut("/authors", async (AuthorModel authorModel, IMediator mediator, IMapper mapper) =>
            {
                try
                {
                    var command = mapper.Map<UpdateAuthorCommand>(authorModel);
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

            return endpoint;
        }
    }
}
