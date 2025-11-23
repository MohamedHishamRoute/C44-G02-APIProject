
using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DataSeed;
using E_Commerce.Persistence.Data.DbContexts;
using E_Commerce.Persistence.Repos;
using E_Commerce.Services;
using E_Commerce.Services.MappingProfiles;
using E_Commerce.Services.MappingProfiles.Resolvers;
using E_Commerce.ServicesAbstraction;
using E_Commerce.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ECommerceDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddAutoMapper(typeof(ServicesAssemblyReference).Assembly); 
            builder.Services.AddTransient<ProductPictureUrlResolver>();
            builder.Services.AddScoped<IDataInitializer, DataInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            
            #endregion


            var app = builder.Build();

            #region Data Seed
            await app.MigrateAsync();
            await app.SeedDataAsync();
            #endregion

            #region Configure the HTTP request pipeline

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.MapControllers();
            #endregion


            await app.RunAsync();
        }
    }
}
