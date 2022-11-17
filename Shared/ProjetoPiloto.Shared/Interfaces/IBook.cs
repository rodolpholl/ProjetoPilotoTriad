namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IBook : IEntityBase
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public DateTime PublishDate { get; set; }
        public short Edition { get; set; }
        public decimal Cost { get; set; }
        public decimal CurrentRetail { get; set; }

        public IList<IAuthor> Author { get; set; }
        public IPublisher Publisher { get; set; }
        public IList<IPromotion> Promotions { get; set; }
    }
}
