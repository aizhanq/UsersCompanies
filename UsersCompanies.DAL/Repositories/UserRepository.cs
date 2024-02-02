using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.EF;
using UsersCompanies.DAL.Entities;
using UsersCompanies.DAL.Interfaces;

namespace UsersCompanies.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        //// TODO
        //public async Task<IEnumerable<Job>> GetJobsByUserIdAsync(int userId)
        //{
        //    var jobs = await _context.Users
        //        .Where(u => u.Id == userId)
        //        .Select(u => u.Jobs)
        //        .ToListAsync();

        //    return null;
        //}                     
    }
}
