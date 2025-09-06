using GymFlow.CustomerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymFlow.CustomerService.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<int> SaveChangesAsync();
        Task<Customer> GetByPhoneAsync(string phone);
        Task<Customer> GetByEmailAsync(string email);
    }
}
