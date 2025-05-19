using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop
{
    public class GlobalSettings
    {
        public const string DefaultEndpoint = "https://localhost:7230/api";

        public string AuthEndpoint { get; set; }
        public string ContractEndpoint { get; set; }
        public string ContractFileEndpoint { get; set; }

        public static GlobalSettings Instance { get; } = new GlobalSettings();

        public GlobalSettings()
        {
            AuthEndpoint = $"{DefaultEndpoint}/Auth";
            ContractEndpoint = $"{DefaultEndpoint}/Contract";
            ContractFileEndpoint = $"{DefaultEndpoint}/ContractFile";
        }
    }
}
