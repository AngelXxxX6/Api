using Domain.Enitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TestResultRepository
    {

        private readonly ApplicationContext _context;

        public TestResultRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TestResult entity)
        {
            await _context.TestResults.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(TestResult entity)
        {
            _context.TestResults.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TestResult>> Select()
        {
            return await _context.TestResults.ToListAsync();
        }

        public async Task<bool> Update(TestResult entity)
        {
            _context.TestResults.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
