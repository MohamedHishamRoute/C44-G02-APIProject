using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Models.BaseClasses;
using E_Commerce.Persistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly Dictionary<Type, object> _repos = [];

        public UnitOfWork(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IGenericRepo<T, TKey> GetRepo<T, TKey>() where T : Base<TKey>
        {
            var type = typeof(T);
            if (_repos.TryGetValue(type, out object? repo)) return (IGenericRepo <T,TKey>)repo;

            var newRepo = new GenericRepo<T, TKey>(_dbContext);
            _repos[type] = newRepo;
            return newRepo;
        }

        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    }
}
