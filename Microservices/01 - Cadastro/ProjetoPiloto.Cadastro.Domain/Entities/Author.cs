using ProjetoPiloto.Shared;
using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Cadastro.Domain.Entities
{
    public class Author : EntityBase, IAuthor
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Alias { get; set; }
    }
}
