using BasicBilling.API.DTO;
using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;

namespace BasicBilling.Utils
{
    public static class BasicBillingEngine
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
    }
}
