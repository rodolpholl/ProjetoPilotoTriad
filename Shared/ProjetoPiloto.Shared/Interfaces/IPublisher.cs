using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IPublisher : IEntityBase
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
    }
}
