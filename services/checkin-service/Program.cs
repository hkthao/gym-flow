// checkin-service/Program.cs
using Serilog;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new Serilog.Formatting.Compact.CompactJsonFormatter())
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.MapGet("/", () => "Hello from Checkin Service!");

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.UseMetricServer(); // Add this line to expose /metrics endpoint
app.UseHttpMetrics(); // Add this line to collect HTTP request metrics

app.Run();

// Ensure to close and flush the logger on application shutdown
Log.CloseAndFlush();