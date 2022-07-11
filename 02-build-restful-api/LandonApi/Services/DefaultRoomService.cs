using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IConfigurationProvider mappingConfig;

        public DefaultRoomService(HotelApiDbContext context, IConfigurationProvider mappingConfig)
        {
            this.context = context;
            this.mappingConfig = mappingConfig;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            var query = context.Rooms.ProjectTo<Room>(mappingConfig);

            return await query.ToArrayAsync();
        }

        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = await context.Rooms.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return null;
            }
            var mapper = mappingConfig.CreateMapper();
            return mapper.Map<Room>(entity);
        }
    }
}
