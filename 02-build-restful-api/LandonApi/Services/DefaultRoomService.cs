using AutoMapper;
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
        private readonly IMapper mapper;

        public DefaultRoomService(HotelApiDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = await context.Rooms.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }

            return mapper.Map<Room>(entity);
        }
    }
}
