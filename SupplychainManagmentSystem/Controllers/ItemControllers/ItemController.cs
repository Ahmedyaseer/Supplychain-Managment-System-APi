using Microsoft.AspNetCore.Mvc;
using Supplychain_Core.ItemService;
using Supplychain_Core.Requests;

namespace SupplychainApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get() 
        {
            var items = _service.GetItems();
            if (items == null) 
                return NotFound();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) 
        {
            var item = _service.GetItemById(id);
            if(item.Name == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Add(ItemRequest request) 
        {
          await _service.AddItemAsync(request);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id ,ItemRequest request) 
        {
            var item = await _service.UpdateItemAsync(id,request);
            if(item == null)
                return NotFound();
            return Ok(item);
        }
    }
}
