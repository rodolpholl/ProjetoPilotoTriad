using ProjetoPiloto.Shared;
using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Cadastro.Domain.Entities
{
    public class Customer : EntityBase, ICustomer
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
    }
}
