using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplychain_Data.Models
{
    public class OrderSupply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Sequence { get; set; }

        public DateTime OrderSupplyDate { get; set; }
        public int WarehouseId { get; set; }

        public int SupplierId { get; set; }

        public Warehouse Warehouse { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderSupplyItems> OrderSupplyItems { get; set; } 
        public ICollection<Item> Items { get; set; }
    }
}
