using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Models.BaseClasses;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repos
{
    public class GenericRepo<T, TKey> : IGenericRepo<T, TKey> where T : Base<TKey>
    {
        private readonly ECommerceDbContext _dbContext;

        public GenericRepo(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();


        public async Task<T?> GetByIdAsync(TKey id) => await _dbContext.Set<T>().FindAsync(id);

        public void Add(T model) => _dbContext.Set<T>().Add(model);

        public void Delete(T entity) => _dbContext.Remove(entity);

        public void Update(T entity) => _dbContext.Update(entity);
    }
}
