using JobManagement.Applicant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories
{
    public interface IApplicantRepository
    {
        Task<user?> GetByIdAsync(long id);
        Task<user?> GetByEmailAsync(string email);
        Task<IEnumerable<user>> GetAllAsync();
        Task AddAsync(user applicant);
        Task UpdateAsync(user applicant);
        Task<bool> ExistsAsync(string email);

   
    }
}
