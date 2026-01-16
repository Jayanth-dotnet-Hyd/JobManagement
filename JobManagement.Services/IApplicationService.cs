using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories.DTOs.JobDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<application>> GetAllApplicationsAsync();
        Task<application?> GetApplicationByIdAsync(long id);

        Task<IEnumerable<application>> GetApplicationsByJobAsync(long jobId);
        Task<IEnumerable<application>> GetApplicationsByApplicantAsync(long applicantId);

        Task ApplyForJobAsync(ApplyJobDto dto );
        Task UpdateStatusAsync(long applicationId, string status);
        Task DeleteApplicationAsync(long applicationId);
    }
}
