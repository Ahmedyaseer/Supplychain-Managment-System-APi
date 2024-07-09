using Microsoft.AspNetCore.Mvc;
using Supplychain_Core.PickingListService;
using Supplychain_Core.Requests;

namespace Supplychain_Api.Controllers.PickingList_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickingListController : ControllerBase
    {
        private readonly IPickingListService _service;

        public PickingListController(IPickingListService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddNewPickingList (PickingListRequest request)
        {
            var newPickingList = _service.AddNewPickingList(request);
            if(newPickingList == null) 
                return NotFound();  
            return Ok(newPickingList);
        }
    }
}
