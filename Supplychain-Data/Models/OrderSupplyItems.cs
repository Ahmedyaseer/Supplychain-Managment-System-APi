using System.ComponentModel;

namespace Supplychain_Data.Models
{
    public class OrderSupplyItems
    {
        public int ItemId {  get; set; }    

        public int OrderSupplyId { get; set; }

        public Item Item { get; set; }
        public OrderSupply OrderSupply { get; set; }

        public int Quantity { get; set; }
        public DateTime ProductionTime { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
