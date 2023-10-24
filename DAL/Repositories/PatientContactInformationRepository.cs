using Domain.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PatientContactInformationRepository
    {
        private readonly ApplicationContext _context;

        public PatientContactInformationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(PatientContactInformation entity)
        {
            await _context.PatientContactInformation.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(PatientContactInformation entity)
        {
            _context.PatientContactInformation.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PatientContactInformation>> Select()
        {
            return await _context.PatientContactInformation.ToListAsync();
        }

        public async Task<bool> Update(PatientContactInformation entity)
        {
            _context.PatientContactInformation.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
