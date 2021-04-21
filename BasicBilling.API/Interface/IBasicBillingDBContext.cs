using BasicBilling.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Interface
{
    public interface IBasicBillingDBContext : IDisposable
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BillStatus> BillStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
