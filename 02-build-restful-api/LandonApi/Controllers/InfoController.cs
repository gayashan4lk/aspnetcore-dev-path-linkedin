using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace LandonApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class InfoController : Controller
    {
        private readonly HotelInfo hotelInfo;

        public InfoController(IOptions<HotelInfo> hotelInfoWrapper)
        {
            this.hotelInfo = hotelInfoWrapper.Value;
        }

        [HttpGet(Name = nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<HotelInfo> GetInfo()
        {
            hotelInfo.Href = Url.Link(nameof(GetInfo), null);

            return hotelInfo;
        }
    }
}
