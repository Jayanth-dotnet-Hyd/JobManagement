using JobManagement.Applicant.Data.Models;
using JobManagement.Repositories;
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
        private readonly ApplicantService _applicantService;
        public ApplicationController(ApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await _applicantService.GetAllApplicantsAsync();
            return Ok(applications);
        }
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetApplicationById(long id)
        {
            var application = await _applicantService.GetApplicantByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateApplication(long id, [FromBody] user applicant)
        {
            await _applicantService.UpdateApplicantProfileAsync(applicant);
            return Ok(new
            {
                success = true,
                message = "Application updated successfully"
            });
        }

    }
}
