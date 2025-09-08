using GymFlow.CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymFlow.CustomerService.Infrastructure.Persistence;
using GymFlow.CustomerService.Domain.Interfaces;

namespace GymFlow.CustomerService.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public virtual async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public virtual async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public virtual void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public virtual void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<Customer> GetByPhoneAsync(string phone)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Phone == phone);
        }

        public virtual async Task<Customer> GetByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public virtual async Task<(IEnumerable<Customer> customers, int totalRecords)> SearchCustomersAsync(string? keyword, string? status, int pageNumber, int pageSize)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(c => c.FullName.Contains(keyword) ||
                                         c.Phone.Contains(keyword) ||
                                         c.Email.Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<Domain.Enums.MembershipStatus>(status, true, out var statusEnum))
            {
                query = query.Where(c => c.MembershipStatus == statusEnum);
            }

            var totalRecords = await query.CountAsync();

            var customers = await query.Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return (customers, totalRecords);
        }
    }
}
