using Microsoft.AspNetCore.Mvc;
using WebShopLearning.Interfaces;

namespace WebShopLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> getUsers()
        {
            var student = await _userService.getAllUsersAsync();
            return Ok(student);

        }
    }
}
