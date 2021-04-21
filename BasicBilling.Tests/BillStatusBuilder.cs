using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBilling.Tests
{
    public class BillStatusBuilder
    {
        private readonly BillStatus _billStatusEntity;
        public BillStatusBuilder()
        {
            _billStatusEntity = new BillStatus
            {
                BillStatusId = 1,
                Status = "Pending"
            };
        }

        public BillStatusBuilder WithBillStatusId(int statusId)
        {
            _billStatusEntity.BillStatusId = statusId;
            return this;
        }

        public BillStatusBuilder WithStatus(string status)
        {
            _billStatusEntity.Status = status;
            return this;
        }

        public BillStatus Build()
        {
            _billStatusEntity.BillStatusId = 1;
            return _billStatusEntity;
        }
    }
}
