using Supplychain_Core.Requests;

namespace Supplychain_Core.Services.OrderSupplyService
{
    public interface IOrderSupplyService
    {
        string AddNewOrderSupply(OrderSupplyRequest request);
        string UpdateOrderSupply(UpdateOrderSupplyRequest request);

    }
}
