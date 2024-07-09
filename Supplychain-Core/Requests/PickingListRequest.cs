namespace Supplychain_Core.Requests
{
    public class PickingListRequest
    {
        public int WarehouseId { get; set; }
        public int CustomerId { get; set; }
        public List<ItemQuantitySold> Items { get; set; }
        public DateTime PickingListTime { get; set; }

    }

    public class ItemQuantitySold
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }   
    } 
}
