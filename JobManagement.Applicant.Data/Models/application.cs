using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Applicant.Data.Models;

[Index("job_id", "applicant_id", Name = "uq_job_applicant", IsUnique = true)]
public partial class application
{
    [Key]
    public long id { get; set; }

    public long job_id { get; set; }

    public long applicant_id { get; set; }

    [StringLength(255)]
    public string? resume_snapshot_url { get; set; }

    public string? cover_letter { get; set; }

    [StringLength(30)]
    public string status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime applied_at { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? updated_at { get; set; }

    [ForeignKey("applicant_id")]
    [InverseProperty("applications")]
    public virtual user applicant { get; set; } = null!;

    [ForeignKey("job_id")]
    [InverseProperty("applications")]
    public virtual job job { get; set; } = null!;
}
