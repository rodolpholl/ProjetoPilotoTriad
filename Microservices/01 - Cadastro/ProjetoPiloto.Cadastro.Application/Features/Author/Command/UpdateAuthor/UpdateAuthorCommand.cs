using MediatR;

namespace ProjetoPiloto.Cadastro.Application.Features.Author.Command.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
    }
}
