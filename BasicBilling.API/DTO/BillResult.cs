using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.DTO
{
    public class BillResult
    {
        public int BillId { get; set; }
        public int Period { get; set; }
        public string Category { get; set; }
        public string Client { get; set; }
        public string Status { get; set; }
        public double Amount { get; set; }
    }
}
