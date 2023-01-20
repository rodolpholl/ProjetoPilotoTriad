using AutoMapper;
using MediatR;
using ProjetoPiloto.Cadastro.API.Modules.Cadastro.Models;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.GetAuthorById;

namespace ProjetoPiloto.Cadastro.API.Modules.Cadastro.Endpoints.Query
{
    public static class GetAuthorById
    {
        public static IEndpointRouteBuilder MapGetAuthor(this IEndpointRouteBuilder endpoint, Serilog.ILogger logger)
        {
            endpoint.MapGet("/authors/{Id}", async (long Id, IMediator mediator, IMapper mapper) =>
            {
                try
                {
                    var query = new GetAuthorByIdQuery(Id);
                    var result = await mediator.Send(query);

                    return Results.Ok(mapper.Map<AuthorModel>(result));
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return Results.BadRequest(ex.Message);
                }
            })
            .WithName("GetAuthorById");
            return endpoint;
        }
    }
}
