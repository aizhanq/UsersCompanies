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
    public class JobRepository : IJobRepository
    {
        private ApplicationContext _context;
        public JobRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> GetJobByIdAsync(int jobId)
        {
            return await _context.Jobs.FindAsync(jobId);
        }

        public async Task CreateJobAsync(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAsync(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobAsync(int jobId)
        {
            var job = await _context.Jobs.FindAsync(jobId);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }
        }

        //// TODO
        //public async Task<IEnumerable<Job>> GetJobsByUserIdAsync(int jobId)
        //{
        //    var jobs = await _context.Users
        //        .Where(u => u.Id == jobId)
        //        .Select(u => u.Jobs)
        //        .ToListAsync();

        //    return null;
        //}
        //                      
    }
}
