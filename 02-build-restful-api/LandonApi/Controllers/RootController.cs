﻿using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LandonApi.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        [ProducesResponseType(200)]
        public IActionResult GetRoot()
        {
            var response = new RootResponse
            {
                Self = Link.To(nameof(GetRoot)),
                Rooms = Link.To(nameof(RoomsController.GetRooms)),
                Info = Link.To(nameof (InfoController.GetInfo)),
            };

            return Ok(response);
        }
    }
}
