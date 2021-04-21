using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBilling.API.Interface
{
    public interface IClientRepository
    {
        Client GetClient(int clientId);
        IEnumerable<Client> GetClients();
    }
}
