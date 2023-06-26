using DAL.Interfaces;
using Domain.Enitity;

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

        public IQueryable<Doctor> Select()
        {
            return _context.Doctors;
        }

        public async Task<bool> Update(Doctor entity)
        {
            _context.Doctors.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
