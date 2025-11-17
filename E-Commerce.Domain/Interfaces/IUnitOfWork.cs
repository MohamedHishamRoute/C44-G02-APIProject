using E_Commerce.Domain.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepo<T, TKey> GetRepo<T, TKey>() where T : Base<TKey>;
        public Task<int> SaveChangesAsync();
    }
}
