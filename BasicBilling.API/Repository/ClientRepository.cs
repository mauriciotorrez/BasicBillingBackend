using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BasicBillingDBContext _context;
        public ClientRepository(BasicBillingDBContext context)
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
