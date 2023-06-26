using DAL.Interfaces;
using Domain.Enitity;

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

        public IQueryable<Patient> Select()
        {
            return _context.Patients;
        }

        public async Task<bool> Update(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
