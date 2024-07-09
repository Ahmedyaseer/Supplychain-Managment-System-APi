using System.ComponentModel.DataAnnotations;

namespace Supplychain_Data.Models
{
    public class Item
    {
        public Item()
        {
                
        }
       
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="Code is required")]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "MeasuringUnit is required")]
        public string MeasuringUnit { get; set; } = string.Empty;
        public ICollection<WarehouseItem> WarehouseItems { get; set; } 
        public ICollection<Warehouse> Warehouses { get; set; } 
        public ICollection<OrderSupplyItems> OrderSupplyItems { get; set; }
        public ICollection<OrderSupply> orderSupplies { get; set; }
        public ICollection<PickingList> pickingLists { get; set; }
        public ICollection<PickingListItems> PickingListItems { get; set; } 
    }
}
