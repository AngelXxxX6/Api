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
    public class DiagnosisRepository : IDiagnosisRepository
    {

        private readonly ApplicationContext _context;

        public DiagnosisRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Diagnosis entity)
        {
            await _context.Diagnoses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Diagnosis entity)
        {
            _context.Diagnoses.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Diagnosis>> Select()
        {
            return await _context.Diagnoses.ToListAsync();
        }

        public async Task<bool> Update(Diagnosis entity)
        {
            _context.Diagnoses.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
