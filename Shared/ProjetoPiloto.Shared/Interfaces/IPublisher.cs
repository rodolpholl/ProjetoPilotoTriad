namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IPublisher : IEntityBase
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
    }
}
