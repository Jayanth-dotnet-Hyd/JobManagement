using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories.DTOs.JobDTOs
{
    public class jobDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Location { get; set; }
        public string? EmploymentType { get; set; }
        public string? ExperienceLevel { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public UserSummaryDto CreatedBy { get; set; } = null!;
    }
}
