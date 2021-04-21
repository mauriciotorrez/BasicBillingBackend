using BasicBilling.API.constant;
using BasicBilling.API.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BasicBilling.API.Models
{
    public class BasicBillingDBContext : DbContext, IBasicBillingDBContext
    {       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=D:\BasicBillingDB.db");

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BillStatus> BillStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Data to bosststrap at the creation time
        /// </summary>
        /// <returns></returns>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillStatus>().HasData(
                DataDB.BillStatusData
            );

            modelBuilder.Entity<Category>().HasData(
                DataDB.CategoryData
            );

            modelBuilder.Entity<Client>().HasData(
                DataDB.ClientData
            );

            List<Bill> billList = new List<Bill>();
            var billId = 1;
            foreach (var client in DataDB.ClientData)
            {
                foreach (var category in DataDB.CategoryData)
                {
                    billList.Add(new Bill
                    {
                        BillId = billId,
                        Period = 202101,
                        Category_Id = category.CategoryId,
                        BillStatus_Id = 2,
                        Client_Id = client.ClientId
                    });
                    billId++;
                    billList.Add(new Bill
                    {
                        BillId = billId,
                        Period = 202102,
                        Category_Id = category.CategoryId,
                        BillStatus_Id = 2,
                        Client_Id = client.ClientId
                    });
                    billId++;
                    billList.Add(new Bill
                    {
                        BillId = billId,
                        Period = 202103,
                        Category_Id = category.CategoryId,
                        BillStatus_Id = 1,
                        Client_Id = client.ClientId
                    });
                    billId++;
                    billList.Add(new Bill
                    {
                        BillId = billId,
                        Period = 202104,
                        Category_Id = category.CategoryId,
                        BillStatus_Id = 1,
                        Client_Id = client.ClientId
                    });
                    billId++;
                }
            }

            Bill[] BillData = billList.ToArray();
            modelBuilder.Entity<Bill>().HasData(
                BillData
            );

            List<Payment> paymentList = new List<Payment>();
            var paymentId = 1;
            foreach (var client in DataDB.ClientData)
            {
                foreach (var category in DataDB.CategoryData)
                {
                    paymentList.Add(new Payment
                    {
                        PayId = paymentId,
                        Period = 202101,
                        Category_Id = category.CategoryId,
                        Client_Id = client.ClientId
                    });
                    paymentId++;
                    paymentList.Add(new Payment
                    {
                        PayId = paymentId,
                        Period = 202102,
                        Category_Id = category.CategoryId,
                        Client_Id = client.ClientId
                    });
                    paymentId++;
                }
            }

            Payment[] PaymentData = paymentList.ToArray();
            modelBuilder.Entity<Payment>().HasData(
                PaymentData
            );

        }

    }
}
