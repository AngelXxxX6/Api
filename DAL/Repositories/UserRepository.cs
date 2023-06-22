
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

        public async Task<bool> DeleteById(int id)
        {

            var a = _context.Users.Where(x => x.Id == id);
            User entity = a.FirstOrDefault();
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;


        }

        public IQueryable<User> Select()
        {
            return _context.Users;
        }

        public async Task<bool> Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
