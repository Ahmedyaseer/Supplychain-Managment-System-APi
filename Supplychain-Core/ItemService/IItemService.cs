using Supplychain_Core.Requests;
using Supplychain_Core.Response;
using Supplychain_Data.Models;

namespace Supplychain_Core.ItemService
{
    public interface IItemService
    {
        List<ItemResponse> GetItems();
        ItemResponse GetItemById(int id);
        Task<Item> UpdateItemAsync(int id ,ItemRequest request);
        Task AddItemAsync(ItemRequest request);

    }
}
