using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories.DTOs.JobDTOs
{
    public class ShortlistedCandidateDto
    {
        public long JobId { get; set; }
        public string JobTitle { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantEmail { get; set; }
    }
}
