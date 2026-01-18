using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Models;

public partial class job
{
    [Key]
    public long id { get; set; }

    [StringLength(150)]
    public string title { get; set; } = null!;

    public string description { get; set; } = null!;

    [StringLength(100)]
    public string? location { get; set; }

    [StringLength(50)]
    public string? employment_type { get; set; }

    [StringLength(50)]
    public string? experience_level { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? salary_min { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? salary_max { get; set; }

    [StringLength(30)]
    public string status { get; set; } = null!;

    public long? created_by { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime created_at { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? updated_at { get; set; }

    [InverseProperty("job")]
    public virtual ICollection<application> applications { get; set; } = new List<application>();

    [ForeignKey("created_by")]
    [InverseProperty("jobs")]
    public virtual user? created_byNavigation { get; set; }
}
