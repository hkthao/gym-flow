using System;
using System.Linq;
using System.Threading.Tasks;
using GymFlow.CustomerService.Domain.Entities;
using GymFlow.CustomerService.Infrastructure.Persistence;
using GymFlow.CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CustomerService.IntegrationTests.Repositories
{
    public class CustomerRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomerRepository _repository;

        public CustomerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationDbContext(options);
            _repository = new CustomerRepository(_context);
        }

        [Fact]
        public async Task SearchCustomersAsync_Should_Return_Filtered_Customers()
        {
            // Arrange
            _context.Customers.Add(new Customer { FullName = "Test User 1", Phone = "1234567890", Email = "test1@test.com" });
            _context.Customers.Add(new Customer { FullName = "Test User 2", Phone = "0987654321", Email = "test2@test.com" });
            await _context.SaveChangesAsync();

            // Act
                        var (customers, totalRecords) = await _repository.SearchCustomersAsync("Test User 1", null, 1, 10);

            // Assert
            Assert.Single(customers);
            Assert.Equal(1, totalRecords);
        }

        [Fact]
        public async Task GetByPhoneAsync_Should_Return_Customer()
        {
            // Arrange
            var customer = new Customer { FullName = "Test User", Phone = "1234567890", Email = "test@test.com" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByPhoneAsync("1234567890");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test User", result.FullName);
        }

        [Fact]
        public async Task GetByEmailAsync_Should_Return_Customer()
        {
            // Arrange
            var customer = new Customer { FullName = "Test User", Phone = "1234567890", Email = "test@test.com" };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByEmailAsync("test@test.com");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test User", result.FullName);
        }
    }
}
