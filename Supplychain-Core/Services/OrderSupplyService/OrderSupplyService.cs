using Microsoft.EntityFrameworkCore;
using Supplychain_Core.Requests;
using Supplychain_Data.Models;
using Supplychain_Data.SystemContext;

namespace Supplychain_Core.Services.OrderSupplyService
{
    public class OrderSupplyService : IOrderSupplyService
    {
        private readonly SystemDbContext _context;

        public OrderSupplyService(SystemDbContext context)
        {
            _context = context;
        }

        public string AddNewOrderSupply(OrderSupplyRequest request)
        {
            List<OrderSupplyItems> orderItem = new List<OrderSupplyItems>();

            foreach (var item in request.Items)
            {
                var orderSupplyItem = new OrderSupplyItems
                {
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                    ExpirationTime = item.ExpirationTime,
                    ProductionTime = item.ProductionTime,
                };

                orderItem.Add(orderSupplyItem);
            }
            var newOrderSupply = new OrderSupply
            {
                WarehouseId = request.WarehouseId,
                SupplierId = request.SupplierId,
                OrderSupplyDate = request.OrderSupplyTime,
                Sequence = GenerateRandomSequence(),
                OrderSupplyItems = orderItem


            };
            _context.OrderSupply.Add(newOrderSupply);
            _context.OrderSupplyItems.AddRange(orderItem);

            foreach (var item in request.Items)
            {

                var currentWarehouseItem = _context.WarehouseItems
                    .FirstOrDefault(r => r.WarehouseId == request.WarehouseId
                    && r.ItemId == item.ItemId);
                if (currentWarehouseItem == null)
                {
                    var newWarehouseItem = new WarehouseItem
                    {
                        WarehouseId = request.WarehouseId,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                    };
                    _context.WarehouseItems.Add(newWarehouseItem);
                }
                else
                {
                    currentWarehouseItem.Quantity += item.Quantity;
                    _context.WarehouseItems.Update(currentWarehouseItem);
                }
            }

            _context.OrderSupply.Add(newOrderSupply);
            _context.SaveChanges();

            return newOrderSupply.Sequence;
        }

        public string UpdateOrderSupply(UpdateOrderSupplyRequest request)
        {
            var sequence = request.Sequence;
            var orderSupply = _context.OrderSupply
                .FirstOrDefault(f => f.Sequence == sequence);

            if (orderSupply == null)
                return "unsuccessful update";

            var orderSupplyId = orderSupply.Id;

            var warehouseId = orderSupply.WarehouseId;

            var orderSupplyWithItems = _context.OrderSupplyItems
                .Where(osi => osi.OrderSupplyId == orderSupplyId).ToList();

            var itemsIds = request.Items.Select(r => r.ItemId).ToList();

            var warehouseItems = _context.WarehouseItems
                .Where(w => w.WarehouseId == warehouseId && itemsIds.Contains(w.ItemId))
                .ToList();

            foreach (var itemRequest in request.Items)
            {
                var updateOrderSupply = orderSupplyWithItems.FirstOrDefault(f => f.ItemId == itemRequest.ItemId);
                if (updateOrderSupply != null)
                    updateOrderSupply.Quantity = itemRequest.Quantity;
                var updateWarehouseItems = warehouseItems.FirstOrDefault(f => f.ItemId == itemRequest.ItemId);
                if (updateWarehouseItems != null)
                    updateWarehouseItems.Quantity = itemRequest.Quantity;
                _context.WarehouseItems.UpdateRange(warehouseItems);
                _context.OrderSupplyItems.UpdateRange(orderSupplyWithItems);
            }
            _context.SaveChanges();
            return "updated";
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
