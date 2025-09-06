using Xunit;
using FluentAssertions;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using GymFlow.CustomerService.Api;
using GymFlow.CustomerService.Domain.Entities;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using GymFlow.CustomerService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;

namespace GymFlow.CustomerService.IntegrationTests
{
    public class CustomersControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public CustomersControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Development"); // Ensure Development environment is used
                builder.ConfigureServices(services =>
                {
                    // Remove the app's ApplicationDbContext registration.
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Add ApplicationDbContext using an in-memory database for testing.
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                    });

                    // Build the service provider.
                    var sp = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database contexts
                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                        // Ensure the database is created.
                        db.Database.EnsureCreated();

                        // Seed the database with test data.
                        if (!db.Customers.Any())
                        {
                            db.Customers.Add(new Customer { Id = Guid.NewGuid(), FullName = "Test Customer 1", Phone = "1111111111", Email = "test1@example.com", MembershipStatus = Domain.Enums.MembershipStatus.Active, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
                            db.Customers.Add(new Customer { Id = Guid.NewGuid(), FullName = "Test Customer 2", Phone = "2222222222", Email = "test2@example.com", MembershipStatus = Domain.Enums.MembershipStatus.Inactive, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
                            db.SaveChanges();
                        }
                    }
                });
            });
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetCustomers_ReturnsSuccessStatusCodeAndCorrectContentType()
        {
            // Arrange

            // Act
            var response = await _client.GetAsync("/api/Customers");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact]
        public async Task GetCustomerById_ReturnsCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = (await _client.GetFromJsonAsync<List<Customer>>("/api/Customers")).First().Id;

            // Act
            var response = await _client.GetAsync($"/api/Customers/{customerId}");

            // Assert
            response.EnsureSuccessStatusCode();
            var customer = await response.Content.ReadAsAsync<Customer>();
            customer.Should().NotBeNull();
            customer.Id.Should().Be(customerId);
        }

        [Fact]
        public async Task PostCustomer_ReturnsCreatedCustomer_WhenCustomerIsValid()
        {
            // Arrange
            var newCustomer = new Customer { FullName = "New API Customer", Phone = "3333333333", Email = "api_new@example.com", MembershipStatus = Domain.Enums.MembershipStatus.Active };
            var json = JsonConvert.SerializeObject(newCustomer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Customers", content);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdCustomer = await response.Content.ReadAsAsync<Customer>();
            createdCustomer.Should().NotBeNull();
            createdCustomer.FullName.Should().Be(newCustomer.FullName);
        }

        [Fact]
        public async Task PutCustomer_ReturnsNoContent_WhenCustomerIsValid()
        {
            // Arrange
            var customerToUpdate = (await _client.GetFromJsonAsync<List<Customer>>("/api/Customers")).First();
            customerToUpdate.FullName = "Updated Name";
            var json = JsonConvert.SerializeObject(customerToUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync($"/api/Customers/{customerToUpdate.Id}", content);

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnsNoContent_WhenCustomerExists()
        {
            // Arrange
            var customerToDeleteId = (await _client.GetFromJsonAsync<List<Customer>>("/api/Customers")).Last().Id;

            // Act
            var response = await _client.DeleteAsync($"/api/Customers/{customerToDeleteId}");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task GetCustomers_WithSearchAndPagination_ReturnsFilteredAndPagedResult()
        {
            // Arrange
            // Seed more data for pagination and search
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                if (!db.Customers.Any(c => c.FullName.Contains("SearchTest")))
                {
                    for (int i = 0; i < 20; i++)
                    {
                        db.Customers.Add(new Customer { Id = Guid.NewGuid(), FullName = $"SearchTest Customer {i}", Phone = $"99999999{i:00}", Email = $"search{i}@example.com", MembershipStatus = Domain.Enums.MembershipStatus.Active, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow });
                    }
                    db.SaveChanges();
                }
            }

            var searchKeyword = "SearchTest";
            var pageNumber = 2;
            var pageSize = 5;

            // Act
            var response = await _client.GetAsync($"/api/Customers?search={searchKeyword}&pageNumber={pageNumber}&pageSize={pageSize}");

            // Assert
            response.EnsureSuccessStatusCode();
            var pagedResult = await response.Content.ReadAsAsync<GymFlow.CustomerService.Domain.Common.PagedResult<GymFlow.CustomerService.Domain.Entities.Customer>>();

            pagedResult.Should().NotBeNull();
            pagedResult.Data.Should().HaveCount(pageSize);
            pagedResult.Pagination.PageNumber.Should().Be(pageNumber);
            pagedResult.Pagination.PageSize.Should().Be(pageSize);
            pagedResult.Pagination.TotalRecords.Should().BeGreaterThanOrEqualTo(20); // At least 20 seeded customers
            pagedResult.Pagination.TotalPages.Should().BeGreaterThanOrEqualTo(4); // 20 customers / 5 per page = 4 pages
        }
    }
}
