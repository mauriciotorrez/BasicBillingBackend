using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationTest
{
    public class TestBillDbSet : IBillRepository
    {
        private readonly TestBasicBillingDBContext _context;
        public TestBillDbSet(TestBasicBillingDBContext context)
        {
            _context = context;
        }
        public Bill Add(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return bill;
        }

        public Bill Delete(int billId)
        {
            Bill bill = _context.Bills.Find(billId);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                _context.SaveChanges();
            }
            return bill;
        }

        public Bill GetBill(int billId)
        {
            if (billId < 1)
            {
                return null;
            }
            return _context.Bills.Find(billId);
        }

        public Bill GetBillByPeriod(int period)
        {
            return _context.Bills.Where(b => b.Period == period).FirstOrDefault();
        }

        public IEnumerable<Bill> GetBills()
        {
            return _context.Bills;
        }

        public IEnumerable<Bill> GetPendingBillsByClientId(int clientId)
        {
            return _context.Bills.Where(b => b.BillStatus_Id == 1 && b.Client_Id == clientId).ToList();
        }

        public Bill Update(Bill billChanges)
        {
            var bill = _context.Bills.Attach(billChanges);
            bill.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return billChanges;
        }
    }
}
