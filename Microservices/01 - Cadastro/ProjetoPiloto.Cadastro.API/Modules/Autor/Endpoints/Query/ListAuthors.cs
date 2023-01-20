using AutoMapper;
using MediatR;
using ProjetoPiloto.Cadastro.API.Modules.Cadastro.Models;
using ProjetoPiloto.Cadastro.Application.Features.Author.Query.ListAuthor;

namespace ProjetoPiloto.Cadastro.API.Modules.Cadastro.Endpoints.Query
{
    public static class ListAuthors
    {
        public static IEndpointRouteBuilder MapListAuthors(this IEndpointRouteBuilder endpoint, Serilog.ILogger logger)
        {
            endpoint.MapGet("/authors/{page}/{size}", async (int page, int size, IMediator mediator, IMapper mapper) =>
            {

                try
                {
                    ListAuthorQuery query = new ListAuthorQuery(page, size);
                    var result = await mediator.Send(query);

                    return Results.Ok(mapper.Map<List<AuthorModel>>(result));
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return Results.BadRequest(ex.Message);
                }

            })
            .WithName("ListAuthors");
            return endpoint;
        }
    }
}
