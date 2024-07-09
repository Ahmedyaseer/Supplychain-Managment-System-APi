using System.ComponentModel.DataAnnotations;

namespace Supplychain_Data.Models
{
    public class Warehouse
    {
        public Warehouse() {   }
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]    
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="Location is required")]
        public string Location { get; set; } = string.Empty ;
        [RegularExpression(@"[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email {  get; set; }
        public Employee Employee { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<WarehouseItem> WearhouseItems { get; set; }
        public ICollection<OrderSupply> OrderSupplies { get; set; }
        public ICollection<PickingList> PickingLists { get; set; }
        
    }
}
