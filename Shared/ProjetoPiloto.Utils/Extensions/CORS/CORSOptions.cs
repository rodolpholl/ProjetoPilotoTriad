using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Utils.Extensions.CORS
{
    public class CORSOptions
    {
        public string PolicyName { get; set; }
        public string[] AllowedOrigins { get; set; }
        public string[] AllowedHeaders { get; set; }
        public string[] AllowedMethods { get; set; }
    }

}
