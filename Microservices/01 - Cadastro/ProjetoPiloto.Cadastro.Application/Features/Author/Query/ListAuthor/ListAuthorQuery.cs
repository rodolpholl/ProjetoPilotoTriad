using MediatR;
using ProjetoPiloto.Cadastro.Application.Models;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Query.ListAuthor
{
    public class ListAuthorQuery : IRequest<List<AuthorModel>>
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
