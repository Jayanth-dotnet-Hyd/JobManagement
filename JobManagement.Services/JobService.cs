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

        public async Task<job?> GetJobByIdAsync(long jobId)
        {
            return await _jobRepository.GetByIdAsync(jobId);
        }

        public async Task<IEnumerable<job>> GetJobsCreatedByAsync(long creatorId)
        {
            return await _jobRepository.GetJobsByCreatorAsync(creatorId);
        }

        public async Task CreateJobAsync(job job, long creatorId)
        {
            job.created_by = creatorId;
            job.status = "OPEN";

            await _jobRepository.AddAsync(job);
        }

        public async Task UpdateJobAsync(job job)
        {
            await _jobRepository.UpdateAsync(job);
        }
    }
}
