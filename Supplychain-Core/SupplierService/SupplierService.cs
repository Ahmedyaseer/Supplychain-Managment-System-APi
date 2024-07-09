using Microsoft.EntityFrameworkCore;
using Supplychain_Core.Requests;
using Supplychain_Core.Response;
using Supplychain_Data.Models;
using Supplychain_Data.SystemContext;

namespace Supplychain_Core.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly SystemDbContext _context;

        public SupplierService(SystemDbContext context)
        {
            _context = context;
        }

        public async Task<SupplierResponse> AddAsync(SupplierRequest request) 
        {
            var supplier = new SupplierResponse
            {
                Name = request.Name,
                WebSite = request.WebSite,
                Mail = request.Mail,
                Phone = request.Phone,
            };
            await _context.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;    

        }

        public async Task<Supplier> UpdateAsync(int id ,SupplierRequest request) 
        {
            var existingSupplier = await _context.Suppliers
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingSupplier ==null)
                return null;
            existingSupplier.Name = request.Name;
            existingSupplier.Phone = request.Phone;
            existingSupplier.WebSite = request.WebSite;
            existingSupplier.Email = request.Mail;   

            _context.Suppliers.Update(existingSupplier);
            await _context.SaveChangesAsync();
            return existingSupplier;

            
        }

        public async Task<List<SupplierResponse>> GetSupplierAsync()
        {
            var suppliers = await _context.Suppliers
                .AsNoTracking()
                .Select(x=>new SupplierResponse
                {
                    WebSite = x.WebSite,
                    Mail = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                })
                .ToListAsync(); 
            if(suppliers == null)
                return null;
            return suppliers;
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            var supplier = await _context.Suppliers
                .AsNoTracking()
                .FirstOrDefaultAsync(s=>s.Id == id);
            if (supplier == null)
                return null;
            return supplier;
        }
    }
}
