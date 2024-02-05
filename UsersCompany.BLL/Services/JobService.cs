using AutoMapper;
using System.ComponentModel.DataAnnotations;
using UsersCompanies.Domain.Entities;
using UsersCompanies.Domain.DTO;
using UsersCompanies.Domain.Repositories;
using UsersCompanies.Domain.Services;

namespace UsersCompanies.BLL.Services
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobDTO>> GetJobsAsync()
        {
            var jobs = await _unitOfWork.Jobs.GetJobsAsync();
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }

        public async Task<JobDTO> GetJobByIdAsync(int jobId)
        {
            var job = await _unitOfWork.Jobs.GetJobByIdAsync(jobId);
            return _mapper.Map<JobDTO>(job);
        }

        public async Task CreateJobAsync(JobDTO jobDTO)
        {
            var job = _mapper.Map<Job>(jobDTO);
            await _unitOfWork.Jobs.CreateJobAsync(job);
        }

        public async Task UpdateJobAsync(JobDTO jobDTO)
        {
            var existingJob = await _unitOfWork.Jobs.GetJobByIdAsync(jobDTO.Id);

            if (existingJob == null)
            {
                // Handling the situation if a task with the specified ID is not found
                throw new ValidationException("Task not found");
            }

            _mapper.Map(jobDTO, existingJob);

            await _unitOfWork.Jobs.UpdateJobAsync(existingJob);
        }

        public async Task DeleteJobAsync(int jobId)
        {
            await _unitOfWork.Jobs.DeleteJobAsync(jobId);
        }

    }
}
