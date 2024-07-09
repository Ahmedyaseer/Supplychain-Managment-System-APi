namespace Supplychain_Data.Models
{
    public  class PickingList
    {
        public int Id { get; set; }


        public string Sequence {  get; set; } 

        public DateTime PickingListTime { get; set; }   

        public int WarehouseId {  get; set; }
        public int CustomerId { get; set; } 

        public Warehouse Warehouse { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<PickingListItems> PickingListItems { get; set; }
    }
}
