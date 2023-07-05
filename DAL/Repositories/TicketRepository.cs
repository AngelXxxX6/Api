using DAL.Interfaces;
using Domain.Enitity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Ticket> GetById(int id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ticket> GetByPatientFIO(string FIO)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.PatientFIO == FIO);
        }

        public async Task<Ticket> GetByDoctorFIO(string FIO)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.DoctorFIO == FIO);
        }

        public async Task<IEnumerable<Ticket>> Select()
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
