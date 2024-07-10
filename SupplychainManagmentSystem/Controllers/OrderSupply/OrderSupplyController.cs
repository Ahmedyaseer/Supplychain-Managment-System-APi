using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supplychain_Core.OrderSupplyService;
using Supplychain_Core.Requests;

namespace Supplychain_Api.Controllers.OrderSupply
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderSupplyController : ControllerBase
    {
        private readonly IOrderSupplyService _service;

        public OrderSupplyController(IOrderSupplyService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(OrderSupplyRequest request)
        {
            var newOrderSupplySequnce = _service.AddNewOrderSupply(request);
            if (newOrderSupplySequnce == null) 
                return BadRequest();  
            return Ok(newOrderSupplySequnce);
        }
        [HttpPut]
        public IActionResult Update(UpdateOrderSupplyRequest request) 
        {
           var update =  _service.UpdateOrderSupply(request);
            if (update == "unsuccessful update")
                return BadRequest();
            return Ok(update);
        }
    }
}
