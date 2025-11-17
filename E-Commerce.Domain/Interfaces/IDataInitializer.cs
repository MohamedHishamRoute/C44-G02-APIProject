using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces
{
    public interface IDataInitializer
    {
        public Task InitializeDataAsync();
    }
}
