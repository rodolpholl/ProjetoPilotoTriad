using MediatR;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Command.AddAuthor
{
    public class AddAuthorCommand : IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
    }
}
