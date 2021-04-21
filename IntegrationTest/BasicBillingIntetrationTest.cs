using BasicBilling.API.Controllers;
using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using BasicBilling.Tests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using BasicBilling.API.DTO;
using System.Net;

namespace IntegrationTest
{
    public class BasicBillingIntetrationTest : IDisposable
    {
        private Mock<ILogger<BillingController>> _logerMock = new Mock<ILogger<BillingController>>(); 
        private TestBillDbSet _testBillRepo = new TestBillDbSet(new TestBasicBillingDBContext());
        private TestBillStatusDbSet _testBillStatusRepo = new TestBillStatusDbSet(new TestBasicBillingDBContext());
        private TestCategoryDbSet _testCategoryRepo = new TestCategoryDbSet(new TestBasicBillingDBContext());
        private TestClientDbSet _testClientRepo = new TestClientDbSet(new TestBasicBillingDBContext());
        private TestPaymentDbSet _testPaymentRepo = new TestPaymentDbSet(new TestBasicBillingDBContext());

        Bill testPendingBill = new BillBuilder()
            .WithId(789)
            .WithPeriod(209901)
            .Build();

        Payment testPaymentCatWater = new PaymentBuilder()
            .WithPeriod(209901)
            .WithCategoryId(1)
            .Build();

        public BasicBillingIntetrationTest()
        {
            
        }

        public void Dispose()
        {

        }

        [Fact]
        public void GetPending_ShouldReturnPendingBill()
        {
            //Arange
            _testBillRepo.Delete(testPendingBill.BillId);
            _testBillRepo.Add(testPendingBill);

            var billingController = new BillingController(_logerMock.Object,
                _testBillRepo,
                _testCategoryRepo,
                _testPaymentRepo,
                _testClientRepo,
                _testBillStatusRepo);

            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = billingController.Pending(1) as JsonResult;

            //Assert
            result.Value.Should().NotBeNull();
            ((List<BillResult>)result.Value)
                .Should().NotBeEmpty()
                .And.Contain(x => x.BillId == testPendingBill.BillId);

        }

        [Fact]
        public void GetSearch_ReturnAllPaymentsByCategory()
        {
            //Arange
            _testBillRepo.Delete(testPendingBill.BillId);
            _testPaymentRepo.Delete(testPaymentCatWater.PayId);
            _testBillRepo.Add(testPendingBill);
            _testPaymentRepo.Add(testPaymentCatWater);

            var billingController = new BillingController(_logerMock.Object,
                _testBillRepo,
                _testCategoryRepo,
                _testPaymentRepo,
                _testClientRepo,
                _testBillStatusRepo);

            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = billingController.Search("WATER") as JsonResult;

            //Assert
            result.Value.Should().NotBeNull();
            ((List<PaymentResult>)result.Value)
                .Should().NotBeEmpty()
                .And.Contain(x => x.PayId == testPaymentCatWater.PayId);
        }

        [Fact]        
        public void PostPay_ShouldRegisterNewPayment()
        {
            //Arange
            _testBillRepo.Delete(testPendingBill.BillId);
            _testPaymentRepo.Delete(testPaymentCatWater.PayId);
            _testBillRepo.Add(testPendingBill);

            var billingController = new BillingController(_logerMock.Object,
                _testBillRepo,
                _testCategoryRepo,
                _testPaymentRepo,
                _testClientRepo,
                _testBillStatusRepo);

            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = billingController.Pay(new PayRequest() { ClientId = 1, Category = "WATER", Period = testPendingBill.Period });

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            (_testPaymentRepo.GetPaymentsByCategory(_testCategoryRepo.GetCategory(1)))
                .Should().NotBeEmpty()
                .And.Contain(x => x.Period == testPendingBill.Period);
        }

        [Fact]
        public void PostBills_ShouldRegisterNewBillForAllClients()
        {
            //Arange
            CleanData();
            //_testBillRepo.Add(testPendingBill);

            var billingController = new BillingController(_logerMock.Object,
                _testBillRepo,
                _testCategoryRepo,
                _testPaymentRepo,
                _testClientRepo,
                _testBillStatusRepo);

            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = billingController.Bills(new BillRequest() { Category = "WATER", Period = testPendingBill.Period });

            //Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            (_testBillRepo.GetPendingBillsByClientId(1))
                .Should().NotBeEmpty()
                .And.Contain(x => x.Period == testPendingBill.Period);
        }

        private void CleanData()
        {
            _testBillRepo.Delete(testPendingBill.BillId);
            _testPaymentRepo.Delete(testPaymentCatWater.PayId);
            foreach (var client in _testClientRepo.GetClients())
            {
                foreach (var bill in _testBillRepo.GetPendingBillsByClientId(client.ClientId))
                {
                    _testBillRepo.Delete(bill.BillId);
                }
            }
        }
    }
}
