using DAL.Interfaces;
using Domain.Enitity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationContext _context;

        public PatientRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Patient entity)
        {
            _context.Patients.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(int id)
        {
            var a = _context.Patients.Where(x => x.Id == id);
            _context.Remove(a);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Patient> GetById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Patient>> Select()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<bool> Update(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
