using JobManagement.Applicant.Data.Models;
using JobManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobManagement.Controllers
{
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
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] job job, long creatorId)
        {
            await _jobService.CreateJobAsync(job, creatorId);
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
    }
}
