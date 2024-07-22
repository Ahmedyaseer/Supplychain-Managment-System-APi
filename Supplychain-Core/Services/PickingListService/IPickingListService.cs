using Supplychain_Core.Requests;

namespace Supplychain_Core.Services.PickingListService
{
    public interface IPickingListService
    {
        string AddNewPickingList(PickingListRequest request);
        void UpdatePickingList(UpdatePickingListRequest request);

    }
}
