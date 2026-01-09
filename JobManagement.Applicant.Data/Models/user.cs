using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Applicant.Data.Models;

[Index("email", Name = "UQ__users__AB6E6164A4A0A22A", IsUnique = true)]
public partial class user
{
    [Key]
    public long id { get; set; }

    public int role_id { get; set; }

    [StringLength(100)]
    public string full_name { get; set; } = null!;

    [StringLength(150)]
    public string email { get; set; } = null!;

    [StringLength(255)]
    public string password_hash { get; set; } = null!;

    [StringLength(15)]
    public string? phone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime created_at { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime updated_at { get; set; }

    [InverseProperty("applicant")]
    public virtual ICollection<application> applications { get; set; } = new List<application>();

    [InverseProperty("created_byNavigation")]
    public virtual ICollection<job> jobs { get; set; } = new List<job>();

    [ForeignKey("role_id")]
    [InverseProperty("users")]
    public virtual role role { get; set; } = null!;
}
