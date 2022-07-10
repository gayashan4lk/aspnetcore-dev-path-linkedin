using LandonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandonApi.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelApiDbContext context;

        public DefaultRoomService(HotelApiDbContext context)
        {
            this.context = context;
        }

        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = await context.Rooms.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return new Room
            {
                Href = null, // For later
                Name = entity.Name,
                Rate = entity.Rate / 100.0m,
            };
        }
    }
}
