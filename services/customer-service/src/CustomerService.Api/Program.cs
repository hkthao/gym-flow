using GymFlow.CustomerService.Application.Interfaces;
using GymFlow.CustomerService.Application.Services;
using GymFlow.CustomerService.Domain.Interfaces; // Added
using GymFlow.CustomerService.Infrastructure.Persistence;
using GymFlow.CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(); // Add NewtonsoftJson for compatibility with ReadAsAsync

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure PostgreSQL DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<GymFlow.CustomerService.Domain.Interfaces.ICustomerRepository, CustomerRepository>();

// Register Services
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Add FluentValidation
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

public partial class Program { } // Make the Program class public for WebApplicationFactory