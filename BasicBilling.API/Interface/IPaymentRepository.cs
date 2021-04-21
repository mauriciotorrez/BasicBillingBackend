using BasicBilling.API.Models;
using System.Collections.Generic;

namespace BasicBilling.API.Interface
{
    public interface IPaymentRepository
    {
        Payment GetPayment(int paymentId);
        IEnumerable<Payment> GetPayments();
        Payment Add(Payment payment);
        Payment Update(Payment paymentChanges);
        Payment Delete(int paymentId);
        IEnumerable<Payment> GetPaymentsByCategory(Category category);
    }
}
