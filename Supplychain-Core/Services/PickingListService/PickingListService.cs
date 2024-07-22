using Microsoft.EntityFrameworkCore;
using Supplychain_Core.Requests;
using Supplychain_Data.Models;
using Supplychain_Data.SystemContext;
using System.Linq;

namespace Supplychain_Core.Services.PickingListService
{
    public class PickingListService : IPickingListService
    {
        private readonly SystemDbContext _context;

        public PickingListService(SystemDbContext context)
        {
            _context = context;
        }

        public string AddNewPickingList(PickingListRequest request)
        {
            var itemsPickingList = new List<PickingListItems>();
            foreach (var item in request.Items)
            {
                var items = new PickingListItems
                {
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                };
                itemsPickingList.Add(items);
            }
            var newPickingList = new PickingList
            {
                WarehouseId = request.WarehouseId,
                CustomerId = request.CustomerId,
                Sequence = GenerateRandomSequence(),
                PickingListTime = request.PickingListTime,
                PickingListItems = itemsPickingList,
            };
            _context.PickingLists.Add(newPickingList);
            _context.PickingListItems.AddRange(itemsPickingList);

            foreach (var item in request.Items)
            {
                var currentWarehouseAndItems = _context.WarehouseItems
                    .FirstOrDefault(x => x.WarehouseId == request.WarehouseId && x.ItemId == item.ItemId);
                if (currentWarehouseAndItems == null)
                    return null;
                currentWarehouseAndItems.Quantity -= item.Quantity;
                _context.WarehouseItems.Update(currentWarehouseAndItems);
            }
            _context.SaveChanges();
            return newPickingList.Sequence;
        }

        public void UpdatePickingList(UpdatePickingListRequest request)
        {
            var sequance = request.Sequence;
            var pickingList = _context.PickingLists
                .FirstOrDefault(f => f.Sequence == sequance);
            if (pickingList == null) return;
            var warehouseId = pickingList.WarehouseId;
            var pickingListItems = _context.PickingListItems
                .Where(p => p.PickingListId == pickingList.Id).ToList();

            var itemIds = request.ItemsSolds.Select(i => i.ItemId).ToList();


            var warehousesItems = _context.WarehouseItems
                .Where(e => e.WarehouseId == warehouseId && itemIds.Contains(e.ItemId)).ToList();


            foreach (var itemRequest in request.ItemsSolds)
            {
                var updatePickingList = pickingListItems.FirstOrDefault(p => p.ItemId == itemRequest.ItemId);
                if (updatePickingList != null)
                {
                    updatePickingList.Quantity = itemRequest.Quantity;
                }

                var updateWarehouseItem = warehousesItems.FirstOrDefault(p => p.ItemId == itemRequest.ItemId);
                if (updateWarehouseItem != null)
                {
                    updateWarehouseItem.Quantity -= itemRequest.Quantity;
                }

                _context.WarehouseItems.UpdateRange(warehousesItems);
                _context.PickingListItems.UpdateRange(pickingListItems);
            }
            _context.SaveChanges();

        }
        private static string GenerateRandomSequence()
        {
            var _random = new Random();
            const string numbers = "0123456789";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] sequence = new char[8];

            // Generate 4 random numbers
            for (int i = 0; i < 4; i++)
            {
                sequence[i] = numbers[_random.Next(numbers.Length)];
            }

            // Generate 4 random characters
            for (int i = 4; i < 8; i++)
            {
                sequence[i] = chars[_random.Next(chars.Length)];
            }

            // Shuffle the sequence
            for (int i = sequence.Length - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                char temp = sequence[i];
                sequence[i] = sequence[j];
                sequence[j] = temp;
            }

            return new string(sequence);
        }
    }
}
