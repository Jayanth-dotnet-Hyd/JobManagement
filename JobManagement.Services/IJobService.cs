using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories.DTOs.JobDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Services
{
    public interface IJobService
    {

        Task<IEnumerable<jobDto>> GetAllJobsAsync();
        Task<IEnumerable<job>> GetOpenJobsAsync();
        Task<job?> GetJobByIdAsync(long jobId);
        Task<IEnumerable<job>> GetJobsCreatedByAsync(long creatorId);
        Task CreateJobAsync(job job, long creatorId);
        Task UpdateJobAsync(job job);

    }
}
