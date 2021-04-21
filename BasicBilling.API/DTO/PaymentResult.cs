using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.DTO
{
    public class PaymentResult
    {
        public int PayId { get; set; }
        public int Period { get; set; }
        public string Category { get; set; }
        public string Client { get; set; }
    }
}
