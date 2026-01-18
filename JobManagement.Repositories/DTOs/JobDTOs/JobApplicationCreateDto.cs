using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories.DTOs.JobDTOs
{
    public class JobApplicationCreateDto
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int GraduationYear { get; set; }
        public string Qualification { get; set; }
        public string ResumeLink { get; set; }
        public string? CoverLetter { get; set; }
    }
}
