using Microsoft.AspNetCore.Mvc;
using Supplychain_Core.Requests;
using Supplychain_Core.Services.PickingListService;

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

        [HttpPut]
        public IActionResult UpdatePickingList(UpdatePickingListRequest request)
        {
            _service.UpdatePickingList(request);
            return Ok();
        }
    }
}
