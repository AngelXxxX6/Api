using Domain.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
   public class RoomRepository
    {
        private readonly ApplicationContext _context;

        public RoomRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Room entity)
        {
            await _context.Rooms.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Room entity)
        {
            _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Room>> Select()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<bool> Update(Room entity)
        {
            _context.Rooms.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
