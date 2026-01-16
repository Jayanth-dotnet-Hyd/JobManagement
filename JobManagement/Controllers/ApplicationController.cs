using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
using JobManagement.Repositories.DTOs.JobDTOs;
using JobManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace JobManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // ======================================
        // Applicant APIs
        // ======================================

        /// <summary>
        /// Apply for a job
        /// </summary>
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForJob([FromBody] ApplyJobDto dto )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _applicationService.ApplyForJobAsync( dto);
                return Ok(new { message = "Job applied successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get applications of a specific applicant
        /// </summary>
        [HttpGet("applicant/{applicantId:long}")]
        public async Task<IActionResult> GetByApplicant(long applicantId)
        {
            var applications = await _applicationService
                .GetApplicationsByApplicantAsync(applicantId);

            return Ok(applications);
        }

        // ======================================
        // HR / Admin APIs
        // ======================================

        /// <summary>
        /// Get applications for a job
        /// </summary>
        [HttpGet("job/{jobId:long}")]
        public async Task<IActionResult> GetByJob(long jobId)
        {
            var applications = await _applicationService
                .GetApplicationsByJobAsync(jobId);

            return Ok(applications);
        }

        /// <summary>
        /// Update application status (HR)
        /// </summary>
        [HttpPut("{applicationId:long}/status")]
        public async Task<IActionResult> UpdateStatus(
            long applicationId,
            [FromQuery] string status)
        {
            try
            {
                await _applicationService.UpdateStatusAsync(applicationId, status);
                return Ok(new { message = "Application status updated." });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // ======================================
        // Common APIs
        // ======================================

        /// <summary>
        /// Get application by id
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);

            if (application == null)
                return NotFound(new { message = "Application not found." });

            return Ok(application);
        }

        /// <summary>
        /// Delete application
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _applicationService.DeleteApplicationAsync(id);
                return Ok(new { message = "Application deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
