using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories.DTOs.JobDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<jobDto>> GetAllAsync();
        Task<jobDto?> GetByIdAsync(long id);
        Task<IEnumerable<job>> GetOpenJobsAsync();
        Task<IEnumerable<job>> GetJobsByCreatorAsync(long creatorId);
        Task AddAsync(job job);
        Task UpdateAsync(job job);
    }
}
