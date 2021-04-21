using BasicBilling.API.constant;
using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTest
{
    public class TestBasicBillingDBContext : DbContext, IBasicBillingDBContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite(@"Data Source=D:\BasicBillingDBTest.db");
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BillStatus> BillStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public void Dispose()
        {
            
        }
    }
}
