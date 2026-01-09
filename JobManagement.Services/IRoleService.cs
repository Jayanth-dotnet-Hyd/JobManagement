using JobManagement.Applicant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Services
{
    public interface IRoleService
    {
        public Task<List<role>> GetAllRoles();
        
        public Task AddRole(role role);
        
    }
}
