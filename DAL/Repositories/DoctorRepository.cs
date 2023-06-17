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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationContext _context;

        public DoctorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Doctor entity)
        {
            await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Doctor entity)
        {
            _context.Doctors.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(int id)
        {
            var a = _context.Doctors.Where(x => x.Id == id);
            _context.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Doctor> GetById(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Doctor>> Select()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<bool> Update(Doctor entity)
        {
            _context.Doctors.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
