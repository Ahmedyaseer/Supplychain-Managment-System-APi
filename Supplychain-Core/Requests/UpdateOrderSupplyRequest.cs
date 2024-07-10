namespace Supplychain_Core.Requests
{
    public class UpdateOrderSupplyRequest
    {
        public string Sequence { get; set; }
        public List<UpdateItems> Items { get; set; }
    }

    public class UpdateItems
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
