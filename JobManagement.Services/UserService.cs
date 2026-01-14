using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
using JobManagement.Repositories.DTOs.JobDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JobManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(user user)
        {
            await _userRepository.AddUser(user);
        }
        public async Task<UserSummaryDto> GetUserSummaryById(long id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return new UserSummaryDto
            {
                Id = user.id,
                full_name = user.full_name,
                email = user.email,
                phone = user.phone,
                role = user.role.role_name  
            };
        }
        public async Task<user> GetUserByEmail(string email)
        {
            var users = await _userRepository.GetUserByEmail(email);
            
            if (users == null)
            {
                throw new Exception("User not found");
            }
            return users;
        }
        public async Task<List<user>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return users;
        }
        public async Task UpdateUser(user user)
        {
            await _userRepository.UpdateUser(user);
        }

    }
}
