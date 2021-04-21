using BasicBilling.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBilling.Tests
{
    public class ClientBuilder
    {
        private readonly Client _categoryEntity;
        public ClientBuilder()
        {
            _categoryEntity = new Client
            {
                ClientId = 1,
                Name = "Joseph Carlton"
            };
        }

        public ClientBuilder WithId(int id)
        {
            _categoryEntity.ClientId = id;
            return this;
        }

        public ClientBuilder Withname(string name)
        {
            _categoryEntity.Name = name;
            return this;
        }

        public Client Build()
        {
            _categoryEntity.ClientId = 1;
            return _categoryEntity;
        }
    }
}
