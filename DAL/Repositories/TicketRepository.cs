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

        

        

        public IQueryable<Ticket> Select()
        {
            return _context.Tickets;
        }

        public async Task<bool> Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
