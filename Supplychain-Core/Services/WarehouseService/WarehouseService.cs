using Microsoft.EntityFrameworkCore;
using Supplychain_Core.Requests;
using Supplychain_Core.Response;
using Supplychain_Data.Models;
using Supplychain_Data.SystemContext;

namespace Supplychain_Core.Services.WarehouseService
{
    public class WarehouseService : IWarehouseService
    {
        private readonly SystemDbContext _context;

        public WarehouseService(SystemDbContext context)
        {
            _context = context;
        }
        public async Task AddWarehouseAsync(WarehouseRequest request)
        {
            var response = new Warehouse
            {
                Location = request.Location,
                Email = request.Email,
                Name = request.Name,
            };

            await _context.Warehouse.AddAsync(response);
            await _context.SaveChangesAsync();

        }

        public List<warehouseResponse> GetWarehouses()
        {
            var response = _context.Warehouse
                .AsNoTracking()
                .Select(w => new warehouseResponse
                {
                    Email = w.Email,
                    Name = w.Name,
                    Location = w.Location,
                })
                .ToList();


            return response;
        }

        public async Task<warehouseResponse> GetWarehouseByIdAsync(int id)
        {
            var warehouse = await _context.Warehouse.
                AsNoTracking().
                FirstOrDefaultAsync(w => w.Id == id);
            if (warehouse == null)
                return null;
            return new warehouseResponse(warehouse);

        }

        public async Task<Warehouse> UpdateWarehouseAsync(int id, WarehouseRequest request)
        {
            var existingWarehouse = await _context.Warehouse
                .FirstOrDefaultAsync(w => w.Id == id);
            if (existingWarehouse == null)
                return null;
            existingWarehouse.Name = request.Name;
            existingWarehouse.Location = request.Location;
            existingWarehouse.Email = request.Email;
            _context.Update(existingWarehouse);
            await _context.SaveChangesAsync();
            return existingWarehouse;
        }

        public List<WarehouseWithEmploye> WarehouseWithEmployee()
        {

            /*
             * null refrence exception
             */
            //var warehouseWithEmployee = _context.Warehouse
            //    .Include(e => e.Employee)
            //    .AsNoTracking()

            //    .Select(x => new WarehouseWithEmploye
            //    {
            //        WarhouseId = x.Id,
            //        WarhouseName = x.Name,
            //        EmployeeId = x.Employee.Id,
            //        EmployeeName = x.Employee.Name ,
            //    }).ToList();

            var warehouseWithEmployee = _context.Warehouse
                .Join(
                _context.Employees,
                w => w.Id,
                e => e.WarehouseId,
                (w, e) => new WarehouseWithEmploye
                {
                    WarhouseId = w.Id,
                    WarhouseName = w.Name,
                    EmployeeId = e.Id,
                    EmployeeName = e.Name,
                }).ToList();

            return warehouseWithEmployee;
        }
    }
}
