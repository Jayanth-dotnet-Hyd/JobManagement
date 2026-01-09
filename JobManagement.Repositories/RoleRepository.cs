using JobManagement.Applicant.Data.Context;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Applicant.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly JobManagementDbContext _context;
        public RoleRepository(JobManagementDbContext context)
        {
            _context = context;
        }

        public async Task AddRole(role role)
        {
            await _context.roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }
        public async Task<List<role>> GetAllRoles()
        {
            return await _context.roles.ToListAsync();
        }

    }
}
