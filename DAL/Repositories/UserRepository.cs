
using DAL.Interfaces;
using Domain.Enitity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<IEnumerable<User>> Select()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
