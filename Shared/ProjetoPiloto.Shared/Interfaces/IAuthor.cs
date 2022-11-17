namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IAuthor : IEntityBase
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Alias { get; set; }
    }
}
