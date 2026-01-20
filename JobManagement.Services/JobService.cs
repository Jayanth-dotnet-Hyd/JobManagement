using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
using JobManagement.Repositories.DTOs.JobDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Services
{
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<jobDto>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllAsync();
        }

        public async Task<IEnumerable<job>> GetOpenJobsAsync()
        {
            return await _jobRepository.GetOpenJobsAsync();
        }

        public async Task<jobDto?> GetJobByIdAsync(long jobId)
        {
            return await _jobRepository.GetByIdAsync(jobId);
        }

        public async Task<IEnumerable<job>> GetJobsCreatedByAsync(long creatorId)
        {
            return await _jobRepository.GetJobsByCreatorAsync(creatorId);
        }

        public async Task CreateJobAsync(CreateJobDto job,long hrId)
        {
            var newJob = new job
            {
                title = job.Title,
                description = job.Description,
                location = job.Location,
                employment_type = job.EmploymentType,
                salary_min = job.MinSalary,
                salary_max = job.MaxSalary,
                created_by = hrId,
                status = "OPEN"
            };

            await _jobRepository.AddAsync(newJob);
        }

        public async Task UpdateJobAsync(job job)
        {
            await _jobRepository.UpdateAsync(job);
        }
    }
}
