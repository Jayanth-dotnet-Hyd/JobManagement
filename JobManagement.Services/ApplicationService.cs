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
    public class ApplicationService:IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<application>> GetAllApplicationsAsync()
        {
            return await _applicationRepository.GetAllAsync();
        }

        public async Task<application?> GetApplicationByIdAsync(long id)
        {
            return await _applicationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<application>> GetApplicationsByJobAsync(long jobId)
        {
            return await _applicationRepository.GetByJobIdAsync(jobId);
        }

        public async Task<IEnumerable<application>> GetApplicationsByApplicantAsync(long applicantId)
        {
            return await _applicationRepository.GetByApplicantIdAsync(applicantId);
        }

        public async Task ApplyForJobAsync(ApplyJobDto dto)
        {
            var exists = await _applicationRepository
        .ExistsAsync(dto.job_id, dto.applicant_id);

            if (exists)
                throw new Exception("You have already applied for this job.");

            var application = new application
            {
                job_id = dto.job_id,
                applicant_id = dto.applicant_id,
                resume_snapshot_url = dto.resume_snapshot_url,
                cover_letter = dto.cover_letter,
                status = "Applied",
                applied_at = DateTime.UtcNow
            };

            await _applicationRepository.AddAsync(application);
        }

        public async Task UpdateStatusAsync(long applicationId, string status)
        {
            var application = await _applicationRepository.GetByIdAsync(applicationId);

            if (application == null)
                throw new Exception("Application not found.");

            application.status = status;
            application.updated_at = DateTime.UtcNow;

            await _applicationRepository.UpdateAsync(application);
        }

        public async Task DeleteApplicationAsync(long applicationId)
        {
            var application = await _applicationRepository.GetByIdAsync(applicationId);

            if (application == null)
                throw new Exception("Application not found.");

            await _applicationRepository.DeleteAsync(application);
        }
    }
}
