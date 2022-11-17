using ProjetoPiloto.Shared;
using ProjetoPiloto.Shared.Enums;
using ProjetoPiloto.Shared.Interfaces;
namespace ProjetoPiloto.Cadastro.Domain.Entities
{
    public class OrderItem : EntityBase, IOrderItem
    {
        public virtual long OrderId { get; set; }
        public virtual long BookId { get; set; }
        public virtual short Quantity { get; set; }
        public virtual decimal RetailPrice { get; set; }
        public virtual PaymentMethod PaidEach { get; set; }
        public virtual IList<IPromotion> Promotions { get; set; }
        public virtual IOrder Order { get; set; }
    }
}
