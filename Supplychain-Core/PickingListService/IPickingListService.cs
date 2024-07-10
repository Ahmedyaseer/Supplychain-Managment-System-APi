using Supplychain_Core.Requests;

namespace Supplychain_Core.PickingListService
{
    public interface IPickingListService
    {
        string AddNewPickingList(PickingListRequest request);
        void UpdatePickingList(UpdatePickingListRequest request);

    }
}
