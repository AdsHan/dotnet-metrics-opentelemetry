using MetricsOpenTelemetry.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MetricsOpenTelemetry.API.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext()
    {

    }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {

    }

    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}

