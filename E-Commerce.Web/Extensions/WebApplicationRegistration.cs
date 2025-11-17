using E_Commerce.Domain.Interfaces;
using E_Commerce.Persistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Web.Extensions
{
    public static class WebApplicationRegistration
    {
        public static async Task<WebApplication> MigrateAsync(this WebApplication app) 
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dbCobtextService = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
            var pendingMigrations = await dbCobtextService.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any()) await dbCobtextService.Database.MigrateAsync();
            return app;
        }

        public static async Task<WebApplication> SeedDataAsync(this WebApplication app) 
        {
            await using var scope = app.Services.CreateAsyncScope();
            var dataInitializerService = scope.ServiceProvider.GetRequiredService<IDataInitializer>();
            await dataInitializerService.InitializeDataAsync();
            return app;
        }
    }
}
