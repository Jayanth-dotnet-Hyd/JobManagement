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
    public class ApplicantRepository : IApplicantRepository
    {

        private readonly JobManagementDbContext _context;

       
        private const int ApplicantRoleId = 1;

      public  ApplicantRepository(JobManagementDbContext context)
        {
            _context = context;
        }

        public async Task<user?> GetByIdAsync(long id)
        {
            return await _context.users
                .Include(u => u.role)
                .FirstOrDefaultAsync(u =>
                    u.id == id &&
                    u.role_id == ApplicantRoleId);
        }

        public async Task<user?> GetByEmailAsync(string email)
        {
            return await _context.users
                .Include(u => u.role)
                .FirstOrDefaultAsync(u =>
                    u.email == email &&
                    u.role_id == ApplicantRoleId);
        }

        public async Task<IEnumerable<user>> GetAllAsync()
        {
            return await _context.users
                .Where(u => u.role_id == ApplicantRoleId)
                .ToListAsync();
        }

        public async Task AddAsync(user applicant)
        {
            _context.users.Add(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(user applicant)
        {
            _context.users.Update(applicant);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _context.users
                .AnyAsync(u =>
                    u.email == email &&
                    u.role_id == ApplicantRoleId);
        }
    }
}
