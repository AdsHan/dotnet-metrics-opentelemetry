using MetricsOpenTelemetry.API.Data.Entities;

namespace MetricsOpenTelemetry.API.Data.Repositories;

public interface IProductRepository : IDisposable
{
    Task<IEnumerable<ProductModel>> GetAllAsync();
    Task SaveAsync();
    void Add(ProductModel obj);
}