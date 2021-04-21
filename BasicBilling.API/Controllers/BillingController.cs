using BasicBilling.API.DTO;
using BasicBilling.API.Engine;
using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BillingController : ControllerBase
    {
        private readonly ILogger<BillingController> _logger;
        private readonly IBillRepository _billRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IPaymentRepository _paymentRepo;
        private readonly IClientRepository _clientRepo;
        private readonly IBillStatusRepository _billStatusRepo;

        public BillingController(ILogger<BillingController> logger,
                                IBillRepository billRepo,
                                ICategoryRepository categoryRepo,
                                IPaymentRepository paymentRepo,
                                IClientRepository clientRepo,
                                IBillStatusRepository billStatusRepo)
        {
            _logger = logger;
            _billRepo = billRepo;
            _categoryRepo = categoryRepo;
            _paymentRepo = paymentRepo;
            _clientRepo = clientRepo;
            _billStatusRepo = billStatusRepo;
        }

        [HttpGet]
        public IActionResult Pending(int ClientId)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            List<BillResult> billResults = new List<BillResult>();
            try
            {
                _ = _clientRepo.GetClient(ClientId) ?? throw new ArgumentException();
                var bills = _billRepo.GetPendingBillsByClientId(ClientId);

                billResults = Helper.GetBillResultFromBills(bills, _categoryRepo,_clientRepo, _billStatusRepo);
            }
            catch 
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }            
            return new JsonResult(billResults);
        }

        [HttpGet]
        public IActionResult Search(string category)
        {
            Response.StatusCode = StatusCodes.Status200OK;
            List<PaymentResult> paymentResults = new List<PaymentResult>();
            try
            {
                var cat = _categoryRepo.GetCategoryByName(category) ?? throw new ArgumentException();
                var payments = _paymentRepo.GetPaymentsByCategory(cat);
                paymentResults = Helper.GetPaymentResultFromPayments(payments, _categoryRepo, _clientRepo);

            }
            catch 
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
            }            
            return new JsonResult(paymentResults);
        }

        [HttpPost]
        public HttpResponseMessage Bills(BillRequest bill)
        {
            HttpResponseMessage response = null;
            string message = string.Empty;
            if (!Helper.ValidPeriod(bill.Period, _billRepo)) throw new ArgumentException("Invalid Period");
            var cat = _categoryRepo.GetCategoryByName(bill.Category) ?? throw new ArgumentException("Invalid Category");
            var clients = _clientRepo.GetClients();            

            try 
            {
                foreach (var client in clients)
                {
                    _billRepo.Add(
                    new Bill
                    {
                        Period = bill.Period,
                        Category_Id = cat.CategoryId,
                        BillStatus_Id = 1,
                        Client_Id = client.ClientId
                    });
                }

                response = new HttpResponseMessage()
                {
                    Content = new StringContent(message),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                message = e.Message;
                response = new HttpResponseMessage()
                {
                    Content = new StringContent(message),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return response;
        }

        [HttpPost]
        public HttpResponseMessage Pay(PayRequest payment)
        {
            HttpResponseMessage response = null;
            string message = string.Empty;            
            var cat = _categoryRepo.GetCategoryByName(payment.Category);
            if (!Helper.ValidPeriodToPay(payment.Period, _billRepo)) throw new ArgumentException("Invalid Period");

            try
            {
                var bill = _billRepo.GetBills().Where(b => 
                (b.Client_Id == payment.ClientId && cat.CategoryId == b.Category_Id && b.Period == payment.Period)).FirstOrDefault();
                _ = bill ?? throw new Exception("Bill not found");

                if (bill.BillStatus_Id == 2) throw new Exception("Bill has been paid");

                bill.BillStatus_Id = 2;
                _billRepo.Update(bill);

                _paymentRepo.Add(
                new Payment
                {
                    Period = payment.Period,
                    Category_Id = cat.CategoryId,
                    Client_Id = payment.ClientId
                });

                response = new HttpResponseMessage()
                {
                    Content = new StringContent(message),
                    StatusCode = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                message = e.Message;
                response = new HttpResponseMessage()
                {
                    Content = new StringContent(message),
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return response;
        }


    }
}

