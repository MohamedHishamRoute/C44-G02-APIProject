using E_Commerce.Domain.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Interfaces
{
    public interface IGenericRepo<T , TKey> where T : Base<TKey>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(TKey id);
        void Add(T model);
        void Update(T entity);

        void Delete(T entity);


    }
}
