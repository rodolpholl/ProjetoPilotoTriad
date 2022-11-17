using ProjetoPiloto.Shared;
using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Cadastro.Domain.Entities
{
    public class Publisher : EntityBase, IPublisher
    {
        public virtual string Name { get; set; }
        public virtual string Contact { get; set; }
        public virtual string Phone { get; set; }
    }
}
