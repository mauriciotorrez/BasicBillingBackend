using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.constant
{
    public static class DataDB
    {
        public static BillStatus[] BillStatusData = new BillStatus[] {
                new BillStatus
                {
                    BillStatusId = 1,
                    Status = "Pending"
                },
                new BillStatus
                {
                    BillStatusId = 2,
                    Status = "Paid"
                }
        };
        public static Category[] CategoryData = new Category[] {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "WATER"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "ELECTRICITY"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "SEWER"
                }
        };
        public static Client[] ClientData = new Client[] {
                new Client
                {
                    ClientId = 1,
                    Name = "Joseph Carlton"
                },
                new Client
                {
                    ClientId = 2,
                    Name = "Maria Juarez"
                },
                new Client
                {
                    ClientId = 3,
                    Name = "Albert Kenny"
                },
                new Client
                {
                    ClientId = 4,
                    Name = "Jessica Phillips"
                },
                new Client
                {
                    ClientId = 5,
                    Name = " Charles Johnson"
                }
        };
        
    }
}
