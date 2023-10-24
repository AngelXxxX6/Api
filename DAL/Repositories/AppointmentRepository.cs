using Domain.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AppointmentRepository
    {
        private readonly ApplicationContext _context;

        public AppointmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Appointment entity)
        {
            await _context.Appointments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Appointment entity)
        {
            _context.Appointments.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Appointment>> Select()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<bool> Update(Appointment entity)
        {
            _context.Appointments.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
