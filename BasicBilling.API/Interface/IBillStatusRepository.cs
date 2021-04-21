using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Interface
{
    public interface IBillStatusRepository
    {
        BillStatus GetBillStatus(int billStatusId);
    }
}
