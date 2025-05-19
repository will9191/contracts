using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop.Models
{
    public class ContractSummaryResponse
    {
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public List<ContractDetailsResponse> Contracts { get; set; } = new List<ContractDetailsResponse>();
        public double TotalValue { get; set; }
        public int MaxDelayDays { get; set; }
    }
}
