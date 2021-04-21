using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTest
{
    public class TestClientDbSet : IClientRepository
    {
        private readonly TestBasicBillingDBContext _context;
        public TestClientDbSet(TestBasicBillingDBContext context)
        {
            _context = context;
        }
        public Client GetClient(int clientId)
        {
            if (clientId < 1)
            {
                return null;
            }
            return _context.Clients.Find(clientId);
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients;
        }
    }
}
