using JobManagement.Applicant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories
{
    public interface IApplicationRepository
    {

        Task<IEnumerable<application>> GetAllAsync();
        Task<application?> GetByIdAsync(long id);
        Task<application?> GetByJobAndApplicantAsync(long jobId, long applicantId);

        Task<IEnumerable<application>> GetByJobIdAsync(long jobId);
        Task<IEnumerable<application>> GetByApplicantIdAsync(long applicantId);

        Task AddAsync(application application);
        Task UpdateAsync(application application);
        Task DeleteAsync(application application);

        Task<bool> ExistsAsync(long jobId, long applicantId);
    }
}
