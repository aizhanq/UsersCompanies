using UsersCompanies.Domain.DTO;

namespace UsersCompanies.Domain.Services
{
    public interface IJobService
    {
        Task<IEnumerable<JobDTO>> GetJobsAsync();
        Task<JobDTO> GetJobByIdAsync(int jobId);
        Task CreateJobAsync(JobDTO jobDTO);
        Task UpdateJobAsync(JobDTO jobDTO);
        Task DeleteJobAsync(int jobId);

        //Task<IEnumerable<UserDTO>> GetUsersByJobIdAsync(int jobId);
    }
}
