using InventoryModels.DTOs;
using InventoryModels.Entity;
using InventoryService.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InventoryApp
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class AuthController : ControllerBase
    {
        private readonly IAuth _authService;

        public AuthController(IAuth authService)
        {
            _authService = authService;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signup)
        {
           
            var result = await _authService.SignUpAsync(signup);
            // continue with signup logic
            return Ok(result);
        }

        [HttpPost("Signin")]
        public async Task<IActionResult> SignIn([FromQuery] SignIn signIn)
        {
            
            var result = await _authService.SignInAsync(signIn);
            // continue with signin logic
            return Ok(result);

        }
    }
}
