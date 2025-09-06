using GymFlow.CustomerService.Application.Interfaces;
using GymFlow.CustomerService.Domain.Entities;
using GymFlow.CustomerService.Domain.Interfaces; // Added
using GymFlow.CustomerService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymFlow.CustomerService.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            // Basic validation (more complex validation will be handled by FluentValidation)
            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                throw new ArgumentException("Full name cannot be empty.");
            }
            if (await _customerRepository.GetByPhoneAsync(customer.Phone) != null)
            {
                throw new ArgumentException("Phone number already exists.");
            }
            if (await _customerRepository.GetByEmailAsync(customer.Email) != null)
            {
                throw new ArgumentException("Email already exists.");
            }

            customer.Id = Guid.NewGuid();
            customer.CreatedAt = DateTime.UtcNow;
            customer.UpdatedAt = DateTime.UtcNow;

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(customer.Id);
            if (existingCustomer == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            // Update properties
            existingCustomer.FullName = customer.FullName;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Email = customer.Email;
            existingCustomer.Birthday = customer.Birthday;
            existingCustomer.Gender = customer.Gender;
            existingCustomer.Address = customer.Address;
            existingCustomer.MembershipStatus = customer.MembershipStatus;
            existingCustomer.UpdatedAt = DateTime.UtcNow;

            _customerRepository.Update(existingCustomer);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customerToDelete = await _customerRepository.GetByIdAsync(id);
            if (customerToDelete == null)
            {
                throw new ArgumentException("Customer not found.");
            }

            _customerRepository.Delete(customerToDelete);
            await _customerRepository.SaveChangesAsync();
        }
    }
}
