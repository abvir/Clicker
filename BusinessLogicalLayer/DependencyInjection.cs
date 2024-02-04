using BusinessLogicalLayer.Base;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicalLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBL(this IServiceCollection services)
    {                
        services.AddScoped<IShortener, Shortener>();
        return services;
    }
}
