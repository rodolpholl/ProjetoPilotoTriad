namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IEntityBase
    {
        public long Id { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
