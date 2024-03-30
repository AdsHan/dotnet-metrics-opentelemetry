using MetricsOpenTelemetry.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddDependencyConfiguration(builder.Configuration);
builder.Services.AddOpenTelemetryConfiguration(builder.Logging, builder.Environment);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseOpenTelemetryConfiguration();
app.UseSwaggerConfiguration();

app.Run();