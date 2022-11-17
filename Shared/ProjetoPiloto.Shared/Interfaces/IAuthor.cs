using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IAuthor : IEntityBase
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Alias { get; set; }
    }
}
