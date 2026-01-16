using JobManagement.Applicant.Data.Context;
using JobManagement.Applicant.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
      
            private readonly JobManagementDbContext _context;

        public ApplicationRepository(JobManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<application>> GetAllAsync()
        {
            return await _context.applications
                .Include(a => a.job)
                .Include(a => a.applicant)
                .ToListAsync();
        }

        public async Task<application?> GetByIdAsync(long id)
        {
            return await _context.applications
                .Include(a => a.job)
                .Include(a => a.applicant)
                .FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task<application?> GetByJobAndApplicantAsync(long jobId, long applicantId)
        {
            return await _context.applications
                .FirstOrDefaultAsync(a =>
                    a.job_id == jobId &&
                    a.applicant_id == applicantId);
        }

        public async Task<IEnumerable<application>> GetByJobIdAsync(long jobId)
        {
            return await _context.applications
                .Where(a => a.job_id == jobId)
                .Include(a => a.applicant)
                .ToListAsync();
        }

        public async Task<IEnumerable<application>> GetByApplicantIdAsync(long applicantId)
        {
            return await _context.applications
                .Where(a => a.applicant_id == applicantId)
                .Include(a => a.job)
                .ToListAsync();
        }

        public async Task AddAsync(application application)
        {
            await _context.applications.AddAsync(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(application application)
        {
            _context.applications.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(application application)
        {
            _context.applications.Remove(application);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(long jobId, long applicantId)
        {
            return await _context.applications
                .AnyAsync(a => a.job_id == jobId && a.applicant_id == applicantId);
        }
    }
    
}
