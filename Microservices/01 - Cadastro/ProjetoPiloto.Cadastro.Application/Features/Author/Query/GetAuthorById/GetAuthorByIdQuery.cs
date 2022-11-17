using MediatR;
using ProjetoPiloto.Cadastro.Application.Models;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Query.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorModel>
    {
        public long Id { get; set; }
    }
}
