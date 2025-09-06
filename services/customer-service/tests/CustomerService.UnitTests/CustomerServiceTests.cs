using Xunit;
using Moq;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using GymFlow.CustomerService.Application.Services;
using GymFlow.CustomerService.Application.Interfaces;
using GymFlow.CustomerService.Domain.Entities;
using GymFlow.CustomerService.Infrastructure.Repositories;
using GymFlow.CustomerService.Domain.Interfaces;
using System.Collections.Generic;

namespace GymFlow.CustomerService.UnitTests
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>(); // No need for null now
            _customerService = new GymFlow.CustomerService.Application.Services.CustomerService(_mockCustomerRepository.Object);
        }

        [Fact]
        public async Task GetCustomerByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var expectedCustomer = new Customer { Id = customerId, FullName = "Test Customer" };
            _mockCustomerRepository.Setup(repo => repo.GetByIdAsync(customerId))
                                   .ReturnsAsync(expectedCustomer);

            // Act
            var result = await _customerService.GetCustomerByIdAsync(customerId);

            // Assert
            result.Should().BeEquivalentTo(expectedCustomer);
        }

        [Fact]
        public async Task CreateCustomerAsync_ShouldCreateCustomer_WhenCustomerIsValid()
        {
            // Arrange
            var newCustomer = new Customer { FullName = "New Customer", Phone = "1234567890", Email = "new@example.com" };
            _mockCustomerRepository.Setup(repo => repo.GetByPhoneAsync(newCustomer.Phone)).ReturnsAsync((Customer)null);
            _mockCustomerRepository.Setup(repo => repo.GetByEmailAsync(newCustomer.Email)).ReturnsAsync((Customer)null);
            _mockCustomerRepository.Setup(repo => repo.AddAsync(It.IsAny<Customer>())).Returns(Task.CompletedTask);
            _mockCustomerRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var createdCustomer = await _customerService.CreateCustomerAsync(newCustomer);

            // Assert
            createdCustomer.Should().NotBeNull();
            createdCustomer.Id.Should().NotBeEmpty();
            _mockCustomerRepository.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Once);
            _mockCustomerRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateCustomerAsync_ShouldThrowArgumentException_WhenPhoneExists()
        {
            // Arrange
            var existingCustomer = new Customer { FullName = "Existing Customer", Phone = "1234567890", Email = "existing@example.com" };
            _mockCustomerRepository.Setup(repo => repo.GetByPhoneAsync(existingCustomer.Phone)).ReturnsAsync(existingCustomer);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _customerService.CreateCustomerAsync(existingCustomer));
        }

        [Fact]
        public async Task UpdateCustomerAsync_ShouldUpdateCustomer_WhenCustomerExists()
        {
            // Arrange
            var existingCustomer = new Customer { Id = Guid.NewGuid(), FullName = "Old Name", Phone = "111", Email = "old@example.com" };
            var updatedCustomer = new Customer { Id = existingCustomer.Id, FullName = "New Name", Phone = "222", Email = "new@example.com" };

            _mockCustomerRepository.Setup(repo => repo.GetByIdAsync(existingCustomer.Id)).ReturnsAsync(existingCustomer);
            _mockCustomerRepository.Setup(repo => repo.Update(It.IsAny<Customer>()));
            _mockCustomerRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _customerService.UpdateCustomerAsync(updatedCustomer);

            // Assert
            _mockCustomerRepository.Verify(repo => repo.Update(It.Is<Customer>(c => c.FullName == "New Name")), Times.Once);
            _mockCustomerRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteCustomerAsync_ShouldDeleteCustomer_WhenCustomerExists()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var customerToDelete = new Customer { Id = customerId, FullName = "To Delete" };
            _mockCustomerRepository.Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(customerToDelete);
            _mockCustomerRepository.Setup(repo => repo.Delete(It.IsAny<Customer>()));
            _mockCustomerRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            await _customerService.DeleteCustomerAsync(customerId);

            // Assert
            _mockCustomerRepository.Verify(repo => repo.Delete(It.Is<Customer>(c => c.Id == customerId)), Times.Once);
            _mockCustomerRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}
