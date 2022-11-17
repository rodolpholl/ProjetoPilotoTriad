using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Shared
{
    public class EntityBase : IEntityBase
    {
        public virtual long Id { get; set; }
        public virtual DateTime UpdateDateTime { get; set; }
        public virtual DateTime CreateDateTime { get; set; }
    }
}