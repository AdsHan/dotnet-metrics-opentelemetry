using MediatR;
using MetricsOpenTelemetry.API.Data.Entities;

namespace MetricsOpenTelemetry.API.Application.Messages.Queries;

public record FindAllProductsQuery : IRequest<List<ProductModel>>;