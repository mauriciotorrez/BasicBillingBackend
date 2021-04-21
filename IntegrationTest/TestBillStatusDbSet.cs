using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTest
{
    public class TestBillStatusDbSet : IBillStatusRepository
    {
        private readonly TestBasicBillingDBContext _context;
        public TestBillStatusDbSet(TestBasicBillingDBContext context)
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
