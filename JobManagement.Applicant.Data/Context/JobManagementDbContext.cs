using System;
using System.Collections.Generic;
using JobManagement.Applicant.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobManagement.Applicant.Data.Context;

public partial class JobManagementDbContext : DbContext
{
    public JobManagementDbContext()
    {
    }

    public JobManagementDbContext(DbContextOptions<JobManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<application> applications { get; set; }

    public virtual DbSet<job> jobs { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ENCDAPHYDLT0041;Database=JobManagementDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<application>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__applicat__3213E83FD25B048B");

            entity.Property(e => e.applied_at).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.status).HasDefaultValue("APPLIED");

            entity.HasOne(d => d.applicant).WithMany(p => p.applications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_applications_user");

            entity.HasOne(d => d.job).WithMany(p => p.applications).HasConstraintName("fk_applications_job");
        });

        modelBuilder.Entity<job>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__jobs__3213E83F00881003");

            entity.Property(e => e.created_at).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.status).HasDefaultValue("OPEN");

            entity.HasOne(d => d.created_byNavigation).WithMany(p => p.jobs).HasConstraintName("fk_jobs_created_by");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__roles__3213E83F8BA0DDD6");

            entity.Property(e => e.created_at).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.updated_at).HasDefaultValueSql("(getutcdate())");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__users__3213E83F7B5F0051");

            entity.Property(e => e.created_at).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.updated_at).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.role).WithMany(p => p.users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__users__role_id__32E0915F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
