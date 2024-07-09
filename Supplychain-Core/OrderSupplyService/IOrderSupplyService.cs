using Supplychain_Core.Requests;

namespace Supplychain_Core.OrderSupplyService
{
    public interface IOrderSupplyService
    {
        string AddNewOrderSupply(OrderSupplyRequest request);

    }
}
