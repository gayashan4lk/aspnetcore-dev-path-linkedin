using Microsoft.AspNetCore.Mvc;

namespace LandonApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            return Ok("I have rooms");
        }
    }
}
