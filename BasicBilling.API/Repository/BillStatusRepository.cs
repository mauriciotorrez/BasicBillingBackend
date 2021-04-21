using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Repository
{
    public class BillStatusRepository : IBillStatusRepository
    {
        private readonly BasicBillingDBContext _context;
        public BillStatusRepository(BasicBillingDBContext context)
        {
            _context = context;
        }
        public BillStatus GetBillStatus(int billStatusId)
        {
            if (billStatusId < 1)
            {
                return null;
            }
            return _context.BillStatuses.Find(billStatusId);
        }
    }
}
