using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supplychain_Core.Requests;
using Supplychain_Core.Services.WarehouseService;
using Supplychain_Data.SystemContext;

namespace SupplychainApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _service;
        private readonly SystemDbContext _context;

        public WarehouseController(IWarehouseService wearhouseService , SystemDbContext context)
        {
            _service = wearhouseService;
            _context = context;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddWearhouse(WarehouseRequest request)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            await  _service.AddWarehouseAsync(request);

            return Created();
        }
        [HttpGet]
       public IActionResult Get()
        {
            var response = _service.GetWarehouses();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var warehouse = await _service.GetWarehouseByIdAsync(id);
            if(warehouse == null)
                return NotFound();
            return Ok(warehouse);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id , WarehouseRequest request) 
        {
            var warehouse = await _service.UpdateWarehouseAsync(id,request);
            if(warehouse == null)
                return NotFound();
            return Ok(warehouse);
        }

        [HttpGet]
        [Route("getemployee")]
        public IActionResult GetEmployee()
        {

            var warehouseWithEmployee = _service.WarehouseWithEmployee();
            if (warehouseWithEmployee == null)
                return NotFound();    
            return Ok(warehouseWithEmployee);
        }

  
    }
}
