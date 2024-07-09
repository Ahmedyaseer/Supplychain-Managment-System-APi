using System.ComponentModel.DataAnnotations;

namespace Supplychain_Data.Models
{
    public class Employee
    {
        public Employee() {  }
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; } = string.Empty ;
        [Required(ErrorMessage ="Phone is required")]
        public int Phone { get; set; }
        public int WarehouseId {  get; set; }
        public Warehouse Warehouse { get; set; } 
    }
}
