using BasicBilling.API.Models;
using System.Collections.Generic;

namespace BasicBilling.API.Interface
{
    public interface IBillRepository
    {
        Bill GetBill(int billId);
        IEnumerable<Bill> GetBills();
        Bill Add(Bill bill);
        Bill Update(Bill billChanges);
        Bill Delete(int billId);
        IEnumerable<Bill> GetPendingBillsByClientId(int clientId);
        Bill GetBillByPeriod(int period);
    }
}
