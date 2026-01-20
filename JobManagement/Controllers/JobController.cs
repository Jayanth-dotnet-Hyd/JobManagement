using JobManagement.Applicant.Data.Models;
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
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }
        [HttpGet("open")]
        public async Task<IActionResult> GetOpenJobs()
        {
            var jobs = await _jobService.GetOpenJobsAsync();
            return Ok(jobs);
        }
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetJobById(long id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }
        [HttpGet("createdBy/{creatorId:long}")]
        public async Task<IActionResult> GetJobsCreatedBy(long creatorId)
        {
            var jobs = await _jobService.GetJobsCreatedByAsync(creatorId);
            return Ok(jobs);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobDto job, long creatorId)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            long hrId = long.Parse(
        User.FindFirst(ClaimTypes.NameIdentifier)!.Value
    );
            await _jobService.CreateJobAsync(job, hrId);
            return Ok(new
            {
                success = true,
                message = "Job created successfully"
            });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateJob([FromBody] job job)
        {
            await _jobService.UpdateJobAsync(job);
            return Ok(new
            {
                success = true,
                message = "Job updated successfully"
            });
        }
        [HttpDelete("{jobId}")]
        public async Task<IActionResult> DeleteJob(long jobId)
        {
            try
            {
                await _jobService.DeleteJobAsync(jobId);
                return Ok(new
                {
                    success = true,
                    message = "Job expired successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
