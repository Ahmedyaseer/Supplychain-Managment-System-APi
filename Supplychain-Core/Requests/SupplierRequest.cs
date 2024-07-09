using System.ComponentModel.DataAnnotations;

namespace Supplychain_Core.Requests
{
    public class SupplierRequest
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public string WebSite { get; set; }
    }
}
