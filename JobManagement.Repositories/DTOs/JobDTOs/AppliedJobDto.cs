using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Repositories.DTOs.JobDTOs
{
    public class AppliedJobDto
    {
        public long JobId { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string EmploymentType { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public DateTime AppliedAt { get; set; }
    }
}
