using ProjetoPiloto.Shared.Enums;

namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IOrderItem : IEntityBase
    {
        public long OrderId { get; set; }
        public long BookId { get; set; }
        public short Quantity { get; set; }
        public decimal RetailPrice { get; set; }
        public IOrder Order { get; set; }
        public PaymentMethod PaidEach { get; set; }

        public IList<IPromotion> Promotions { get; set; }
    }


}

