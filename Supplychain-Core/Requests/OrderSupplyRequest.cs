namespace Supplychain_Core.Requests
{
    public class OrderSupplyRequest
    {
        public int WarehouseId { get; set; }
        public int SupplierId { get; set; }
        public List<ItemQuantity> Items { get; set; }
        public DateTime OrderSupplyTime { get; set; }


    }

    public class ItemQuantity
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionTime { get; set; } 
        public DateTime ExpirationTime { get; set; }
    }
}
