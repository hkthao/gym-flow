using GymFlow.CustomerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymFlow.CustomerService.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid id);
    }
}
