using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompanies.DAL.Entities;

namespace UsersCompanies.DAL.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        Task<Job> GetJobByIdAsync(int id);
        Task CreateJobAsync(Job user);
        Task UpdateJobAsync(Job user);
        Task DeleteJobAsync(int id);

        //Task<IEnumerable<User>> GetUsersByJobIdAsync(int id);
    }
}
