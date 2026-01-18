using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Applicant.Data.Models;

[Index("applicant_id", "job_id", Name = "UQ_applicant_job", IsUnique = true)]
[Index("job_id", "applicant_id", Name = "uq_job_applicant", IsUnique = true)]
public partial class application
{
    [Key]
    public long id { get; set; }

    public long job_id { get; set; }

    public long applicant_id { get; set; }

    [StringLength(255)]
    public string? resume_url { get; set; }

    public string? cover_letter { get; set; }

    [StringLength(30)]
    public string status { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime applied_at { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? updated_at { get; set; }

    [StringLength(100)]
    public string applicant_name { get; set; } = null!;

    [StringLength(150)]
    public string applicant_email { get; set; } = null!;

    [StringLength(20)]
    public string phone { get; set; } = null!;

    [StringLength(250)]
    public string address { get; set; } = null!;

    public int graduation_year { get; set; }

    [StringLength(100)]
    public string qualification { get; set; } = null!;

    [ForeignKey("applicant_id")]
    [InverseProperty("applications")]
    public virtual user applicant { get; set; } = null!;

    [ForeignKey("job_id")]
    [InverseProperty("applications")]
    public virtual job job { get; set; } = null!;
}

