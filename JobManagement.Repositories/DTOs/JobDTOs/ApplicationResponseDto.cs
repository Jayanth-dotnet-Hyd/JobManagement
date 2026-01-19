using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories.DTOs.JobDTOs
{
    public class ApplicationResponseDto
    {

        public long Id { get; set; }

        public long JobId { get; set; }

        public long ApplicantId { get; set; }

        public string? ResumeUrl { get; set; }

        public string? CoverLetter { get; set; }

        public string Status { get; set; } = null!;

        public DateTime AppliedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string ApplicantName { get; set; } = null!;

        public string ApplicantEmail { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int GraduationYear { get; set; }

        public string Qualification { get; set; } = null!;
    }
}
