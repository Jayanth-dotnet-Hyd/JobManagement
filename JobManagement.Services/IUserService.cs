using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories.DTOs.JobDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Services
{
    public interface IUserService
    {
        public Task<List<user>> GetAllUsers();
        public Task<UserSummaryDto> GetUserSummaryById(long id);
        public Task<user> GetUserByEmail(string email);
        public Task AddUser(user user);
        public Task UpdateUser(user user);
    }
}
