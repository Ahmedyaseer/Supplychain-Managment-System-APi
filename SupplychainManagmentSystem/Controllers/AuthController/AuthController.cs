using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supplychain_Core.Requests;
using Supplychain_Core.Services.AuthService;

namespace Supplychain_Api.Controllers.AuthController
{
    [Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        [Route("tokens")]
        public async Task<IActionResult> AccessToken (AuthModelRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  
            var response = await _authService.RegisterAsync(request);
            if(!response.IsAuthenticated)
                return BadRequest(response.Message);
            return Ok(response);
            
        }
}
}
