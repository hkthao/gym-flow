using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymFlow.CustomerService.Domain.Entities;
using GymFlow.CustomerService.Infrastructure.Persistence;
using GymFlow.CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

using Moq.EntityFrameworkCore;

namespace CustomerService.UnitTests.Repositories
{
    public class CustomerRepositoryTests
    {
        private readonly Mock<ApplicationDbContext> _contextMock;
        private readonly CustomerRepository _repository;

        public CustomerRepositoryTests()
        {
            _contextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            _repository = new CustomerRepository(_contextMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Customer()
        {
            // Arrange
            var customer = new Customer { Id = Guid.NewGuid(), FullName = "Test User" };
            _contextMock.Setup(c => c.Customers.FindAsync(customer.Id)).ReturnsAsync(customer);

            // Act
            var result = await _repository.GetByIdAsync(customer.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customer.FullName, result.FullName);
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Customers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = Guid.NewGuid(), FullName = "Test User 1" },
                new Customer { Id = Guid.NewGuid(), FullName = "Test User 2" }
            };
            _contextMock.Setup(c => c.Customers).ReturnsDbSet(customers);

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}
