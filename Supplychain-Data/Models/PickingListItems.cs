namespace Supplychain_Data.Models
{
    public  class PickingListItems
    {
        public int PickingListId { get; set; }
        public int ItemId {  get; set; }    

        public PickingList PickingList { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
