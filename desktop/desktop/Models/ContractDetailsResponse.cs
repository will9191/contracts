using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop.Models
{
    public class ContractDetailsResponse
    {
        public int ContractNumber { get; set; }
        public string Product { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public double Value { get; set; }
    }
}
