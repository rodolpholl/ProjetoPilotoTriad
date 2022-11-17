using ProjetoPiloto.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IOrderItem : IEntityBase
    {
        public long OrderId { get; set; }
        public long BookId { get; set; }
        public short Quantity { get; set; }
        public decimal RetailPrice { get; set; }
        public PaymentMethod PaidEach {get;set;}

        public IList<IPromotion> Promotions { get; set; }
    }

  
}

