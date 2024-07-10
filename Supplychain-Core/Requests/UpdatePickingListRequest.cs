namespace Supplychain_Core.Requests
{
    public class UpdatePickingListRequest
    {
        public string Sequence { get; set; }    

        public List<UpdateItemsSold> ItemsSolds { get; set; }
    }

    public class UpdateItemsSold
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
