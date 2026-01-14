using JobManagement.Applicant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories.DTOs.JobDTOs
{
    public class UserSummaryDto
    {
        public long Id { get; set; }
        public string full_name { get; set; } = null!;
        public string phone { get; set; }
        public string email { get; set; } = null!;
        public role role { get; set; }
    }
}
