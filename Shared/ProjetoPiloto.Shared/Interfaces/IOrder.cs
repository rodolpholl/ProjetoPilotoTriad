using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IOrder : IEntityBase
    {
        public string OrderCode { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime ShipDateTime { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipZipCode{ get; set; }
        public decimal? ShipCost { get; set; }
        public decimal TotalRetail { get; set; }

        public ICustomer Customer { get; set; }
        public IList<IOrderItem> Items { get; set; }

    }
}
