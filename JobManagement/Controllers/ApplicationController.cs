using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
using JobManagement.Repositories.DTOs.JobDTOs;
using JobManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


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

       
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForJob([FromBody] JobApplicationCreateDto dto )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            int userId = int.Parse(
     User.FindFirst(ClaimTypes.NameIdentifier)!.Value
 );
            try
            {
                await _applicationService.ApplyForJobAsync(userId, dto);
                return Ok(new { message = "Job applied successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        
        [HttpGet("applicant/{applicantId:long}")]
        public async Task<IActionResult> GetByApplicant(long applicantId)
        {
            var applications = await _applicationService
                .GetApplicationsByApplicantAsync(applicantId);

            return Ok(applications);
        }
       
        [HttpGet("applied")]
        public async Task<IActionResult> GetAppliedJobs()
        {
            int userId = int.Parse(
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value
            );

            var result = await _applicationService.GetAllAppliedJobsAsync(userId);
            return Ok(result);
        }

        [HttpGet("job/{jobId:long}")]
        public async Task<IActionResult> GetByJob(long jobId)
        {
            var applications = await _applicationService
                .GetApplicationsByJobAsync(jobId);

            return Ok(applications);
        }

        
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

        
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);

            if (application == null)
                return NotFound(new { message = "Application not found." });

            return Ok(application);
        }

        
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
