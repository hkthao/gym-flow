// auth-service/Program.cs
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(new Serilog.Formatting.Compact.CompactJsonFormatter())
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.MapGet("/", () => "Hello from Auth Service!");

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();

// Ensure to close and flush the logger on application shutdown
Log.CloseAndFlush();