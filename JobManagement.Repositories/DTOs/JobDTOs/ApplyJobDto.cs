using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories.DTOs.JobDTOs
{
    public class ApplyJobDto
    {
        public long job_id { get; set; }
        public long applicant_id { get; set; }
        public string? resume_snapshot_url { get; set; }
        public string? cover_letter { get; set; }
    }
}
