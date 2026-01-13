using JobManagement.Applicant.Data.Context;
using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories.DTOs.JobDTOs;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories
{
    public class JobRepository:IJobRepository
    {
        private readonly JobManagementDbContext _context;

        public JobRepository(JobManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<jobDto>> GetAllAsync()
        {
            return await _context.jobs
              .Include(j => j.created_byNavigation)
              .Select(j => new jobDto
              {
                  Id = j.id,
                  Title = j.title,
                  Description = j.description,
                  Location = j.location,
                  EmploymentType = j.employment_type,
                  ExperienceLevel = j.experience_level,
                  SalaryMin = j.salary_min,
                  SalaryMax = j.salary_max,
                  Status = j.status,
                  CreatedAt = j.created_at,

                  CreatedBy = new UserSummaryDto
                  {
                      Id = j.created_byNavigation!.id,
                      FullName = j.created_byNavigation.full_name,
                      Email = j.created_byNavigation.email
                  }
              })
              .ToListAsync();
        }

        public async Task<job?> GetByIdAsync(long id)
        {
            return await _context.jobs
                .Include(j => j.applications)
                .Include(j => j.created_byNavigation)
                .FirstOrDefaultAsync(j => j.id == id);
        }

        public async Task<IEnumerable<job>> GetOpenJobsAsync()
        {
            return await _context.jobs
                .Where(j => j.status == "OPEN")
                .ToListAsync();
        }

        public async Task<IEnumerable<job>> GetJobsByCreatorAsync(long creatorId)
        {
            return await _context.jobs
                .Where(j => j.created_by == creatorId)
                .ToListAsync();
        }

        public async Task AddAsync(job job)
        {
            job.created_at = DateTime.UtcNow;
            _context.jobs.Add(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(job job)
        {
            job.updated_at = DateTime.UtcNow;
            _context.jobs.Update(job);
            await _context.SaveChangesAsync();
        }
    }
}
