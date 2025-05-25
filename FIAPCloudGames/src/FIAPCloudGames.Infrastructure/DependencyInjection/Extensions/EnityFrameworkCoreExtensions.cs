using FIAPCloudGames.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIAPCloudGames.Infrastructure.DependencyInjection.Extensions
{
    public static class EnityFrameworkCoreExtensions
    {
        public static IServiceCollection AddEntityFrameworkCoreConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FIAPCloudGamesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
