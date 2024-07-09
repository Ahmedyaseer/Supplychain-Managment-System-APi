using Microsoft.EntityFrameworkCore;
using Supplychain_Core.Requests;
using Supplychain_Core.Response;
using Supplychain_Data.Models;
using Supplychain_Data.SystemContext;

namespace Supplychain_Core.ItemService
{
    public class ItemService : IItemService
    {
        private readonly SystemDbContext _context;

        public ItemService(SystemDbContext context)
        {
            _context = context;
        }

        public List<ItemResponse> GetItems()
        {
          var items = _context.Items
                .AsNoTracking()
                .Select(i=> new ItemResponse
          {
              Code = i.Code,
              Description = i.Description,
              Id = i.Id,
              MeasuringUnit = i.MeasuringUnit,
              Name = i.Name,
          })
                .ToList(); 
            return items;
        }

        public ItemResponse GetItemById(int id) 
        {
            var item =  _context.Items
                .AsNoTracking()
                .FirstOrDefault(i => i.Id == id);
            if (item == null)
                return new ItemResponse();
            return new ItemResponse(item);
        }

        public async Task<Item> UpdateItemAsync(int id, ItemRequest request) 
        {
            var existingItem =await _context.Items.FirstOrDefaultAsync(item => item.Id ==id);
            if(existingItem == null) return null;
            existingItem.Name = request.Name;
            existingItem.Code = request.Code;
            existingItem.Description = request.Description;
            _context.Items.Update(existingItem);
           await _context.SaveChangesAsync();
            return existingItem;

        }

        public async Task AddItemAsync (ItemRequest request)
        {
            var newItem = new Item()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                MeasuringUnit= request.MeasuringUnit,
                
            };
           await _context.Items.AddAsync(newItem);
           await _context.SaveChangesAsync();
        }
    }
}
