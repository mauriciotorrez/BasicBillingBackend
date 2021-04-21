using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBilling.Tests
{
    public class BillBuilder
    {
        private readonly Bill _billEntity;
        public BillBuilder()
        {
            _billEntity = new Bill
            {
                BillId = 1,
                Period = 202101,
                BillStatus_Id = 1,
                Amount = 0,
                Client_Id = 1,
                Category_Id = 1
            };
        }

        public BillBuilder WithPeriod(int period)
        {
            _billEntity.Period = period;
            return this;
        }

        public BillBuilder WithId(int billId)
        {
            _billEntity.BillId = billId;
            return this;
        }

        public Bill Build()
        {
            return _billEntity;
        }
    }
}
