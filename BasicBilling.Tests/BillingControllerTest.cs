using BasicBilling.API.Controllers;
using BasicBilling.API.DTO;
using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;

namespace BasicBilling.Tests
{
    public class BillingControllerTest
    {
        public Mock<ILogger<BillingController>> _logerMock;
        public Mock<IBillRepository> _billMock;
        public Mock<IBillStatusRepository> _BillStatusMock;
        public Mock<IClientRepository> _clientMock;
        public Mock<IPaymentRepository> _paymentMock;
        public Mock<ICategoryRepository> _categoryMock;


        public void BillingControllerTestSetup()
        {
            _logerMock = new Mock<ILogger<BillingController>>();
            _billMock = new Mock<IBillRepository>();
            _BillStatusMock = new Mock<IBillStatusRepository>();
            _clientMock = new Mock<IClientRepository>();
            _paymentMock = new Mock<IPaymentRepository>();
            _categoryMock = new Mock<ICategoryRepository>();
        }

        [Fact]
        public void Pending_ReturnActionResult__WithPendingBill()
        {
            //Arange
            var bill = new BillBuilder().Build();
            var billStatus = new BillStatusBuilder().Build();
            var category = new CategoryBuilder().Build();
            var client = new ClientBuilder().Build();

            BillingControllerTestSetup();
            var billingController = new BillingController(_logerMock.Object,
                _billMock.Object,
                _categoryMock.Object,
                _paymentMock.Object,
                _clientMock.Object,
                _BillStatusMock.Object);

            billingController.ControllerContext = new ControllerContext();
            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            _clientMock.Setup(repo => repo.GetClient(1))
                .Returns(client);

            _billMock.Setup(billRepo => billRepo.GetPendingBillsByClientId(1))
                .Returns(new List<Bill> { bill });

            _BillStatusMock.Setup(repo => repo.GetBillStatus(1))
                .Returns(billStatus);

            _categoryMock.Setup(repo => repo.GetCategory(1))
                .Returns(category);


            //// Act
            var result = billingController.Pending(1);

            //// Assert
            result.Should().NotBeNull()
                .And.BeAssignableTo<JsonResult>();

            var viewResult = Assert.IsType<JsonResult>(result);
            var model = Assert.IsAssignableFrom<List<BillResult>>(
                viewResult.Value);
            Assert.Single(model);


        }

        [Fact]
        public void Search_ReturnActionResult__WithAllPaymentsByCategory()
        {
            // Arrange
            var bill = new BillBuilder().Build();
            var billStatus = new BillStatusBuilder().Build();
            var category = new CategoryBuilder().Build();
            var client = new ClientBuilder().Build();
            var payment = new PaymentBuilder().Build();            

            BillingControllerTestSetup();
            var billingController = new BillingController(_logerMock.Object,
                _billMock.Object,
                _categoryMock.Object,
                _paymentMock.Object,
                _clientMock.Object,
                _BillStatusMock.Object);

            billingController.ControllerContext = new ControllerContext();
            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            _clientMock.Setup(repo => repo.GetClient(1))
                .Returns(client);

            _billMock.Setup(billRepo => billRepo.GetPendingBillsByClientId(1))
                .Returns(new List<Bill> { bill });

            _BillStatusMock.Setup(repo => repo.GetBillStatus(1))
                .Returns(billStatus);

            _categoryMock.Setup(repo => repo.GetCategoryByName("WATER"))
                .Returns(category);

            _categoryMock.Setup(repo => repo.GetCategory(1))
                .Returns(category);

            _paymentMock.Setup(repo => repo.GetPaymentsByCategory(category))
                .Returns(new List<Payment> { payment });


            // Act
            var result = billingController.Search("WATER");

            // Assert
            result.Should().NotBeNull()
                .And.BeAssignableTo<JsonResult>();

            var viewResult = Assert.IsType<JsonResult>(result);
            var model = Assert.IsAssignableFrom<List<PaymentResult>>(
                viewResult.Value);
            Assert.Single(model);


        }

        [Fact]
        public void Bills_ReturnResponse_AndRegisterNewBillForAllClients()
        {
            // Arrange
            var bill = new BillBuilder().Build();
            var billStatus = new BillStatusBuilder().Build();
            var category = new CategoryBuilder().Build();
            var client = new ClientBuilder().Build();
            var payment = new PaymentBuilder().Build();

            BillingControllerTestSetup();
            var billingController = new BillingController(_logerMock.Object,
                _billMock.Object,
                _categoryMock.Object,
                _paymentMock.Object,
                _clientMock.Object,
                _BillStatusMock.Object);

            billingController.ControllerContext = new ControllerContext();
            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            _clientMock.Setup(repo => repo.GetClient(1))
                .Returns(client);

            _clientMock.Setup(repo => repo.GetClients())
                .Returns(new List<Client> { client });

            _billMock.Setup(billRepo => billRepo.GetPendingBillsByClientId(1))
                .Returns(new List<Bill> { bill });

            _billMock.Setup(billRepo => billRepo.GetBillByPeriod(202102))
                .Returns( bill );

            _BillStatusMock.Setup(repo => repo.GetBillStatus(1))
                .Returns(billStatus);

            _categoryMock.Setup(repo => repo.GetCategoryByName("WATER"))
                .Returns(category);

            _categoryMock.Setup(repo => repo.GetCategory(1))
                .Returns(category);

            _paymentMock.Setup(repo => repo.GetPaymentsByCategory(category))
                .Returns(new List<Payment> { payment });


            // Act
            var result = billingController.Bills(new BillRequest() { Period = 202102, Category = "WATER" });

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public void Pay_ReturnResponse__AndRegisterNewPayment()
        {
            // Arrange
            var bill = new BillBuilder().Build();
            var billStatus = new BillStatusBuilder().Build();
            var category = new CategoryBuilder().Build();
            var client = new ClientBuilder().Build();
            var payment = new PaymentBuilder().Build();

            BillingControllerTestSetup();
            var billingController = new BillingController(_logerMock.Object,
                _billMock.Object,
                _categoryMock.Object,
                _paymentMock.Object,
                _clientMock.Object,
                _BillStatusMock.Object);

            billingController.ControllerContext = new ControllerContext();
            billingController.ControllerContext.HttpContext = new DefaultHttpContext();

            _clientMock.Setup(repo => repo.GetClient(1))
                .Returns(client);

            _clientMock.Setup(repo => repo.GetClients())
                .Returns(new List<Client> { client });

            _billMock.Setup(billRepo => billRepo.GetPendingBillsByClientId(1))
                .Returns(new List<Bill> { bill });

            _billMock.Setup(billRepo => billRepo.GetBillByPeriod(202103))
                .Returns(bill);

            _billMock.Setup(billRepo => billRepo.GetBills())
                .Returns(new List<Bill> { bill });

            _BillStatusMock.Setup(repo => repo.GetBillStatus(1))
                .Returns(billStatus);

            _categoryMock.Setup(repo => repo.GetCategoryByName("WATER"))
                .Returns(category);

            _categoryMock.Setup(repo => repo.GetCategory(1))
                .Returns(category);

            _paymentMock.Setup(repo => repo.GetPaymentsByCategory(category))
                .Returns(new List<Payment> { payment });


            // Act
            var result = billingController.Pay(new PayRequest() { Period = 202101, Category = "WATER", ClientId = 1 });

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);

        }

    }
}
