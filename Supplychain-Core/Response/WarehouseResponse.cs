using Supplychain_Data.Models;

namespace Supplychain_Core.Response
{
    public  class warehouseResponse
    {
        public warehouseResponse()
        {
            Name = "null";
            Location = "null";
            Email = "null";
        }

        public warehouseResponse(Warehouse warehouse )
        {
            Name=warehouse.Name;
            Location=warehouse.Location;
            Email=warehouse.Email;
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }

    }
}
