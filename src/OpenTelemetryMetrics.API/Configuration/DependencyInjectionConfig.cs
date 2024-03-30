using MetricsOpenTelemetry.API.Application.Messages.Commands;
using MetricsOpenTelemetry.API.Application.Services;
using MetricsOpenTelemetry.API.Data;
using MetricsOpenTelemetry.API.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MetricsOpenTelemetry.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("CatalogDB"));

        services.AddTransient<ProductPopulateService>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly);
        });

        return services;
    }
}
