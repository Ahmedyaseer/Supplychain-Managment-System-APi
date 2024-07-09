using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supplychain_Data.Models
{
    
    public class Supplier
    {
        public Supplier() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string WebSite { get; set; }

        public ICollection<OrderSupply> OrderSupplies { get; set; }

    }
}
