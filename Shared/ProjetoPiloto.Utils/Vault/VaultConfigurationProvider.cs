using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPiloto.Utils.Vault
{
    public class VaultConfigurationProvider
    {
        private readonly VaultOptions _config;

        public VaultConfigurationProvider(VaultOptions config)
        {
            _config = config;
        }
    }
}
