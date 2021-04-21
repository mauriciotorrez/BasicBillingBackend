using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.DTO
{
    public class BillRequest
    {
        public int Period { get; set; }
        public string Category { get; set; }
    }
}
