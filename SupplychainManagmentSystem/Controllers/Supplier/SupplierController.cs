using Microsoft.AspNetCore.Mvc;
using Supplychain_Core.Requests;
using Supplychain_Core.SupplierService;

namespace Supplychain_Api.Controllers.Supplier
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get() 
        {
            var suppliers = await _service.GetSupplierAsync();
            if(suppliers == null)  
                return NotFound();  
            return Ok(suppliers);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var supplier = await _service.GetSupplierByIdAsync(id); 
            if(supplier == null)
                return NotFound();
            return Ok(supplier);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add([FromBody]SupplierRequest request)
        {
            var supplier = await _service.AddAsync(request);
            return Ok(supplier);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id ,[FromBody]SupplierRequest request) 
        {
            var supplier = await _service.UpdateAsync(id,request);
            if(supplier == null)
                return NotFound();
            return Ok(supplier);
        }
    }
}
