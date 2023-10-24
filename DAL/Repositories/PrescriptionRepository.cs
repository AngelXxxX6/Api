using Domain.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
   public class PrescriptionRepository
    {

        private readonly ApplicationContext _context;

        public PrescriptionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Prescription entity)
        {
            await _context.Prescriptions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Prescription entity)
        {
            _context.Prescriptions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Prescription>> Select()
        {
            return await _context.Prescriptions.ToListAsync();
        }

        public async Task<bool> Update(Prescription entity)
        {
            _context.Prescriptions.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
