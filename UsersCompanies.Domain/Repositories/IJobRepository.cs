using UsersCompanies.Domain.Entities;

namespace UsersCompanies.Domain.Repositories
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
