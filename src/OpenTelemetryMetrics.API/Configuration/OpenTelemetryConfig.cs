using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace MetricsOpenTelemetry.API.Configuration;

public static class OpenTelemetryConfig
{
    public static IServiceCollection AddOpenTelemetryConfiguration(this IServiceCollection services, ILoggingBuilder logging, IWebHostEnvironment environment)
    {

        logging.AddOpenTelemetry(x =>
        {
            x.IncludeScopes = true;
            x.IncludeFormattedMessage = true;
        });

        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource
                .AddService(serviceName: environment.ApplicationName))
            .WithTracing(x => x
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddSource(MeterConfig.Source.Name)
                .AddConsoleExporter())
            .WithMetrics(x => x
                // Métricas OpenTelemetry
                .AddMeter(MeterConfig.Meter.Name)
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                // Métricas .NET 
                .AddMeter("Microsoft.AspNetCore.Hosting")
                .AddMeter("System.Net.Http")
                .AddMeter("OpenTelemetryMetrics.API")
                .AddConsoleExporter()
                .AddPrometheusExporter());

        return services;
    }

    public static WebApplication UseOpenTelemetryConfiguration(this WebApplication app)
    {
        app.MapPrometheusScrapingEndpoint();

        return app;
    }

    public static class MeterConfig
    {
        public static string ServiceName { get; } = "TesteOpenTelemtry";
        public static ActivitySource Source { get; set; } = new ActivitySource(ServiceName);
        public static Meter Meter { get; set; } = new Meter(ServiceName, "1.0.0");
        public static Counter<int> Requests { get; set; } = Meter.CreateCounter<int>(
            name: "requests",
            description: "Número de requests"
        );
    }
}
