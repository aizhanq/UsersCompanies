using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersCompany.BLL.DTO;

namespace UsersCompany.BLL.Interfaces
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
