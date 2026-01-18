using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
using JobManagement.Repositories.DTOs.JobDTOs;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<AppliedJobDto>> GetAllAppliedJobsAsync(int userId)
        {
            // Repository already filters + includes Job
            var applications = await _applicationRepository
                .GetByApplicantIdAsync(userId);

            // Map Entity → DTO
            return applications.Select(a => new AppliedJobDto
            {
                JobId = a.job_id,
                JobTitle = a.job.title,
                Location = a.job.location,
                EmploymentType = a.job.employment_type,
                MinSalary = a.job.salary_min,
                MaxSalary = a.job.salary_max,
                AppliedAt = a.applied_at
            }).ToList();
        }

        public async Task<IEnumerable<application>> GetApplicationsByApplicantAsync(long applicantId)
        {
            return await _applicationRepository.GetByApplicantIdAsync(applicantId);
        }

        public async Task ApplyForJobAsync(int userId, JobApplicationCreateDto dto)
        {
            
            bool alreadyApplied = await _applicationRepository
                .ExistsAsync(dto.JobId, userId);

            if (alreadyApplied)
                throw new Exception("You already applied for this job.");

           
            var application = new application
            {
                job_id = dto.JobId,
                applicant_id = userId,

                applicant_name = dto.ApplicantName,
                applicant_email = dto.ApplicantEmail,
                phone = dto.Phone,
                address = dto.Address,
                graduation_year = dto.GraduationYear,
                qualification = dto.Qualification,

                resume_url = dto.ResumeLink,
                cover_letter = dto.CoverLetter,

                status = "Applied",
                applied_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow
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
