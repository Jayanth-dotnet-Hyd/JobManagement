using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicantRepository _applicantRepository;
        public UserService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task AddUser(user user)
        {
            await _applicantRepository.AddAsync(user);
        }
        public async Task<user> GetUserById(int id)
        {
            var user = await _applicantRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }
        public async Task<List<user>> GetAllUsers()
        {
            var users = await _applicantRepository.GetAllAsync();
            return users.ToList();
        }
        public async Task UpdateUser(user user)
        {
            await _applicantRepository.UpdateAsync(user);
        }

    }
}
