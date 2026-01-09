using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Applicant.Data.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;


namespace JobManagement.Repositories
{
    public interface IRoleRepository
    {
        public Task<List<role>> GetAllRoles();
        public Task AddRole(role role);
       
       

    }
}
