using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BasicBillingDBContext _context;
        public PaymentRepository(BasicBillingDBContext context)
        {
            _context = context;
        }
        public Payment Add(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return payment;
        }

        public Payment Delete(int paymentId)
        {
            Payment payment = _context.Payments.Find(paymentId);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
            return payment;
        }

        public Payment GetPayment(int paymentId)
        {
            if (paymentId < 1)
            {
                return null;
            }
            return _context.Payments.Find(paymentId);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _context.Payments;
        }

        public IEnumerable<Payment> GetPaymentsByCategory(Category category)
        {
            return _context.Payments.Where(b => b.Category_Id == category.CategoryId).ToList();
        }

        public Payment Update(Payment paymentChanges)
        {
            var payment = _context.Payments.Attach(paymentChanges);
            payment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return paymentChanges;
        }
    }
}
