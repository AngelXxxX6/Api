using DAL.Interfaces;
using Domain.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TicketRepository : ITicketRepository
    {

        private readonly ApplicationContext _context;

        public TicketRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Ticket entity)
        {
            await _context.Tickets.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(int id)
        {
            var a = _context.Tickets.Where(x => x.Id == id);
            _context.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Ticket> GetById(int id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Ticket>> Select()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<bool> Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
