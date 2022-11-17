using ProjetoPiloto.Shared;
using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Cadastro.Domain.Entities
{
    public class Promotion : EntityBase, IPromotion
    {
        public virtual string Name { get; set; }
        public virtual decimal Discount { get; set; }
        public virtual decimal? MinRetail { get; set; }
        public virtual decimal? MaxRetail { get; set; }
        public virtual short? MinQuantity { get; set; }
        public virtual short? MaxQuantity { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual bool Active { get; set; }
    }
}
