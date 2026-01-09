using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Applicant.Data.Models;

[Index("code", Name = "UQ__roles__357D4CF9D017A124", IsUnique = true)]
[Index("role_name", Name = "UQ__roles__783254B1BC3D106D", IsUnique = true)]
public partial class role
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string role_name { get; set; } = null!;

    public int code { get; set; }

    [StringLength(200)]
    public string? description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime created_at { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime updated_at { get; set; }

    [InverseProperty("role")]
    public virtual ICollection<user> users { get; set; } = new List<user>();
}
