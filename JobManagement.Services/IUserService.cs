using JobManagement.Applicant.Data.Models;
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
        public Task<user> GetUserById(int id);
        public Task AddUser(user user);
        public Task UpdateUser(user user);
    }
}
