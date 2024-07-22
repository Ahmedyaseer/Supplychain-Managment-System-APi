using Supplychain_Core.Requests;
using Supplychain_Data.Models;

namespace Supplychain_Core.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(CustomerRequest request);
        Task<Customer> UpdateAsync(CustomerRequest request);
        Task<List<Customer>> GetSupplierAsync();
        Task<Customer> GetSupplierByIdAsync(int id);




    }
}
