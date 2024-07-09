using Supplychain_Data.Models;

namespace Supplychain_Core.Response
{
    public class ItemResponse
    {
        public ItemResponse()
        {
            Name = null;
            Description = null;
            Code = null;
            MeasuringUnit = null;
            
        }
        public ItemResponse(Item  item)
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            Code = item.Code;
            MeasuringUnit = item.MeasuringUnit;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string MeasuringUnit { get; set; }
    }
}
