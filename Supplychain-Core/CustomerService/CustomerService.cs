using Microsoft.EntityFrameworkCore;
using Supplychain_Core.Requests;
using Supplychain_Data.Models;
using Supplychain_Data.SystemContext;

namespace Supplychain_Core.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly SystemDbContext _context;

        public CustomerService(SystemDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(CustomerRequest request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                Eamil = request.Eamil,
                Phone = request.Phone,
                Website = request.Website,
            };
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;

        }

        public async Task<Customer> UpdateAsync(CustomerRequest request)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(s => s.Id == request.Id);
            if (existingCustomer == null)
                return null;
            existingCustomer.Name = request.Name;
            existingCustomer.Phone = request.Phone;
            existingCustomer.Website = request.Website;
            existingCustomer.Eamil = request.Eamil;

            _context.Customers.Update(existingCustomer);
            await _context.SaveChangesAsync();
            return existingCustomer;


        }

        public async Task<List<Customer>> GetSupplierAsync()
        {
            var customer = await _context.Customers.AsNoTracking().ToListAsync();
            if (customer == null)
                return null;
            return customer;
        }

        public async Task<Customer> GetSupplierByIdAsync(int id)
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            if (customer == null)
                return null;
            return customer;
        }
    }
}
