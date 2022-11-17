using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IPromotion : IEntityBase
    {
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public decimal? MinRetail { get; set; }
        public decimal? MaxRetail { get; set; }
        public short? MinQuantity { get; set; }
        public short? MaxQuantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
    }
}
