using Api.Bibiliotheque.Core.Net.Interfaces;
using Api.Bibiliotheque.Core.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Bibiliotheque.Core.Net.Services
{

    public class UserService : IUserService
    {

        private readonly BibliothequeContext _context;

        public UserService(BibliothequeContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var result = await _context.User.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<UserModel?> GetUser(int id)
        {
            var result = await _context.User.AsNoTracking().Where(user=>user.Id==id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached;

            return user;
        }

        public async Task<UserModel?> UpdateUser(int id, UserModel user)
        {
            if (user.Id != id)
                return null;

            var result = await _context.User.AsNoTracking().Where(user => user.Id == id).FirstOrDefaultAsync();
            if (result == null)
                return null;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(user).State = EntityState.Detached;

            return user;
        }

        public async Task<UserModel?> DeleteUser(int id)
        {
            var result = await _context.User.FindAsync(id);
            if (result == null)
                return null;

            _context.User.Remove(result);
            await _context.SaveChangesAsync();
            _context.Entry(result).State = EntityState.Detached;

            return (result);
        }


    }
}
