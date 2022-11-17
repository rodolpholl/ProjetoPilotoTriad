using ProjetoPiloto.Shared;
using ProjetoPiloto.Shared.Interfaces;

namespace ProjetoPiloto.Cadastro.Domain.Entities
{
    public class Order : EntityBase, IOrder
    {
        public virtual string OrderCode { get; set; }
        public virtual DateTime OrderDateTime { get; set; }
        public virtual DateTime ShipDateTime { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual string ShipCity { get; set; }
        public virtual string ShipState { get; set; }
        public virtual string ShipZipCode { get; set; }
        public virtual decimal? ShipCost { get; set; }
        public virtual decimal TotalRetail { get; set; }
        public virtual ICustomer Customer { get; set; }
        public virtual IList<IOrderItem> Items { get; set; }
    }
}
