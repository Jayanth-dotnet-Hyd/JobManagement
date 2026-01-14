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
    public class UserRepository : IUserRepository
    {
        private readonly JobManagementDbContext _context;

        public UserRepository(JobManagementDbContext context)
        {
            _context = context;
        }
        public async Task<List<user>> GetAllUsers()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<user> GetUserById(long userId)
        {

            var user = await _context.users
                      .Include(u => u.role)
                      .FirstOrDefaultAsync(u => u.id == userId);
            return user;

        }
        public async Task<user> GetUserByEmail(string email)
        {
            return await _context.users.FirstOrDefaultAsync(u => u.email == email);
        }
        public async Task<user> AddUser(user user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<user> UpdateUser(user user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
