using ProjetoPiloto.Shared;
using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Cadastro.Domain.Entities
{
    public class Book : EntityBase, IBook
    {
        public virtual string Title { get; set; }
        public virtual string ISBN { get; set; }
        public virtual string Category { get; set; }
        public virtual DateTime PublishDate { get; set; }
        public virtual short Edition { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual decimal CurrentRetail { get; set; }
        public virtual IList<IAuthor> Author { get; set; }
        public virtual IPublisher Publisher { get; set; }
        public virtual IList<IPromotion> Promotions { get; set; }

    }
}
