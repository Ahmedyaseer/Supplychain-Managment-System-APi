using System.ComponentModel.DataAnnotations;

namespace Supplychain_Core.Requests
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public int Phone { get; set; }
        public string Eamil { get; set; }
    }
}
