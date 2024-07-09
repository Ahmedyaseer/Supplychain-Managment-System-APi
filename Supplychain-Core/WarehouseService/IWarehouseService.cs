using Supplychain_Core.Requests;
using Supplychain_Core.Response;
using Supplychain_Data.Models;

namespace Supplychain_Core.WearhouseService
{
    public interface IWarehouseService
    {
        Task AddWarehouseAsync(WarehouseRequest request);
        List<warehouseResponse> GetWarehouses();
        Task<warehouseResponse> GetWarehouseByIdAsync(int id);
        Task<Warehouse> UpdateWarehouseAsync(int id, WarehouseRequest request);
        List<WarehouseWithEmploye> WarehouseWithEmployee();



    }
}
