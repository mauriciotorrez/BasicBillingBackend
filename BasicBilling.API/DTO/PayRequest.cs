using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.DTO
{
    public class PayRequest
    {
        public int Period { get; set; }
        public string Category { get; set; }
        public int ClientId { get; set; }
    }
}
