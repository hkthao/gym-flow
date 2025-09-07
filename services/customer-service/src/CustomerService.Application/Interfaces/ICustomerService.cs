using GymFlow.CustomerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymFlow.CustomerService.Domain.Common;
using GymFlow.CustomerService.Application.DTOs;

namespace GymFlow.CustomerService.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid id);
        Task<PagedResult<CustomerDto>> SearchCustomersAsync(string? keyword, int pageNumber, int pageSize);
    }
}
