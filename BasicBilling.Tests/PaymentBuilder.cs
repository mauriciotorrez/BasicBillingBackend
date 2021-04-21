using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBilling.Tests
{
    public class PaymentBuilder
    {
        private readonly Payment _paymentEntity;
        public PaymentBuilder()
        {
            _paymentEntity = new Payment
            {
                PayId = 1,
                Period = 202101,
                Category_Id = 1,
                Client_Id = 1
            };
        }

        public PaymentBuilder WithPeriod(int period)
        {
            _paymentEntity.Period = period;
            return this;
        }

        public PaymentBuilder WithClientId(int cliendId)
        {
            _paymentEntity.Client_Id = cliendId;
            return this;
        }

        public PaymentBuilder WithCategoryId(int catId)
        {
            _paymentEntity.Category_Id = catId;
            return this;
        }

        public Payment Build()
        {
            return _paymentEntity;
        }
    }
}
