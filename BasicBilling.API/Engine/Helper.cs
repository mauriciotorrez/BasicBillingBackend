using BasicBilling.API.DTO;
using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Engine
{
    public static class Helper
    {
        public static List<BillResult> GetBillResultFromBills(IEnumerable<Bill> bills,
                                                    ICategoryRepository categoryRepo,
                                                    IClientRepository clientRepo,
                                                    IBillStatusRepository billStatusRepo)
        {
            List<BillResult> billResults = new List<BillResult>();
            foreach (var bill in bills)
            {
                billResults.Add(
                    new BillResult()
                    {
                        BillId = bill.BillId,
                        Category = categoryRepo.GetCategory(bill.Category_Id).CategoryName,
                        Client = clientRepo.GetClient(bill.Client_Id).Name,
                        Period = bill.Period,
                        Amount = bill.Amount,
                        Status = billStatusRepo.GetBillStatus(bill.BillStatus_Id).Status
                    }); ;
            }
            return billResults;
        }

        public static List<PaymentResult> GetPaymentResultFromPayments(IEnumerable<Payment> payments,
                                            ICategoryRepository categoryRepo,
                                            IClientRepository clientRepo)
        {
            List<PaymentResult> paymentResults = new List<PaymentResult>();
            foreach (var payment in payments)
            {
                paymentResults.Add(
                    new PaymentResult()
                    {
                        PayId = payment.PayId,
                        Category = categoryRepo.GetCategory(payment.Category_Id).CategoryName,
                        Client = clientRepo.GetClient(payment.Client_Id).Name,
                        Period = payment.Period
                    }); ;
            }
            return paymentResults;
        }

        internal static bool ValidPeriod(int period, IBillRepository billRepo)
        {
            if (period.ToString().Length != 6 ) return false;
            if (billRepo.GetBillByPeriod(period) != null) return false;
            return true;
        }

        internal static bool ValidPeriodToPay(int period, IBillRepository billRepo)
        {
            if (period.ToString().Length != 6) return false;
            if (billRepo.GetBillByPeriod(period) == null) return false;
            return true;
        }
    }
}
