using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Models.BaseClasses;
using E_Commerce.Domain.Models.ProductModule;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Data.DataSeed
{
    public class DataInitializer : IDataInitializer
    {
        private readonly ECommerceDbContext _dbContext;

        public DataInitializer(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InitializeDataAsync()
        {
            try 
            {
                var hasProducts = await _dbContext.Products.AnyAsync();
                var hasTypes = await _dbContext.ProductTypes.AnyAsync();
                var hasBrands = await _dbContext.ProductBrands.AnyAsync();
                if(hasProducts && hasTypes && hasBrands) return ;

                if (!hasBrands) await seedModelDataFromJsonFileAsync<ProductBrand,int>("brands.json", _dbContext.ProductBrands);
                if (!hasTypes) await seedModelDataFromJsonFileAsync<ProductType, int>("types.json", _dbContext.ProductTypes);
                await _dbContext.SaveChangesAsync();
            
                if (!hasProducts) 
                    await seedModelDataFromJsonFileAsync<Product, int>("products.json", _dbContext.Products);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            
        }

        private async Task seedModelDataFromJsonFileAsync<T , TKey>(string fileName , DbSet<T> dbSet) where T : Base<TKey> 
        {
            try 
            { 
                var path = @"..\E-Commerce.Persistence\Data\DataSeed\JsonFiles\" + fileName;
                if (!File.Exists(path)) throw new FileNotFoundException(); 
                using var dataStream = File.OpenRead(path);
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };
                var data = await JsonSerializer.DeserializeAsync<List<T>>(dataStream,options);
                if (data is not null) dbSet.AddRange(data);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return;
            }
        }
    }
}
