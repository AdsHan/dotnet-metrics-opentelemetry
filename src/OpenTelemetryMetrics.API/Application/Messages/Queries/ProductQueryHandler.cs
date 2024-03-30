using MediatR;
using MetricsOpenTelemetry.API.Controllers;
using MetricsOpenTelemetry.API.Data.Entities;
using MetricsOpenTelemetry.API.Data.Repositories;
using static MetricsOpenTelemetry.API.Configuration.OpenTelemetryConfig;

namespace MetricsOpenTelemetry.API.Application.Messages.Queries;

public class ProductQueryHandler : IRequestHandler<FindAllProductsQuery, List<ProductModel>>

{
    private readonly IProductRepository _productRepository;

    public ProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductModel>> Handle(FindAllProductsQuery request, CancellationToken cancellationToken)
    {
        using var activity = MeterConfig.Source.StartActivity("FindAllProducts");
        activity?.SetTag("Teste", 1);

        MeterConfig.Requests.Add(1, new("Action", nameof(Index)), new("Controller", nameof(ProductsController)));

        var products = await _productRepository.GetAllAsync();

        return products.ToList();
    }
}
