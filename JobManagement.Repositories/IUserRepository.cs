using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Applicant.Data.Models;

namespace JobManagement.Repositories
{
    public interface IUserRepository
    {
        public Task<user> GetUserById(int userId);
        public Task<user> GetUserByEmail(string email);
        public Task<user> AddUser(user user);
        public Task<user> UpdateUser(user user);
        public Task<List<user>> GetAllUsers();

    }
}
