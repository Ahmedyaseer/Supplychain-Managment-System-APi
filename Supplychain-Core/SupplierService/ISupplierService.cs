using Supplychain_Core.Requests;
using Supplychain_Core.Response;
using Supplychain_Data.Models;

namespace Supplychain_Core.SupplierService
{
    public interface ISupplierService
    {
        Task<SupplierResponse> AddAsync(SupplierRequest request);
        Task<Supplier> UpdateAsync(int id ,SupplierRequest request);
        Task<List<SupplierResponse>> GetSupplierAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);




    }
}
