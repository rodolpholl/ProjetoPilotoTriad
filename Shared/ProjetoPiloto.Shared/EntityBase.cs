using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Shared
{
    public class EntityBase : IEntityBase
    {
        public long Id { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}