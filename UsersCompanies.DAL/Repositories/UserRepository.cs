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
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
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
        //    var jobs = await _context.UserJob
        //        .Where(uj => uj.UserId == userId)
        //        .Select(uj => uj.Job)
        //        .ToListAsync();

        //    return jobs;
        //}
    }
}
