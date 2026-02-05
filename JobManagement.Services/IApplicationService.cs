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
        Task<IEnumerable<ShortlistedCandidateDto>> GetShortlistedCandidates();
        Task<IEnumerable<ApplicationResponseDto>> GetApplicationsByJobAsync(long jobId);
        Task<List<AppliedJobDto>> GetAllAppliedJobsAsync(int userId);
        Task<IEnumerable<AppliedJobDto>> GetApplicationsByApplicantAsync(long applicantId);

        Task ApplyForJobAsync(int userId, JobApplicationCreateDto dto);

        Task DeleteApplicationAsync(long applicationId);
        Task UpdateApplicationStatusAsync(long applicationId, string status);

    }
}
