using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task AddRole(role role)
        {
            await _roleRepository.AddRole(role);
        }

        public async Task<List<role>> GetAllRoles()
        {
            return await _roleRepository.GetAllRoles();
        }

    }
}
