using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDAL(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ShortUrlContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PostgresConnection")));    
        
        services.AddScoped<IUrlAddressRepository, UrlAddressRepository>();
        return services;
    }
}
