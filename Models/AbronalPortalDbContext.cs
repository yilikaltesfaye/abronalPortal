using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace abronalPortal.Models;

public partial class AbronalPortalDbContext : DbContext
{
    public AbronalPortalDbContext()
    {
    }

    public AbronalPortalDbContext(DbContextOptions<AbronalPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicantTestProject> ApplicantTestProjects { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<Decision> Decisions { get; set; }

    public virtual DbSet<TestProjectTemplate> TestProjectTemplates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=localhost;Database=abronalPortalDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicantTestProject>(entity =>
        {
            entity.HasKey(e => e.ApplicantTestProjectId).HasName("PK__Applican__7D28F6B2616F8143");

            entity.HasIndex(e => e.ApplicationId, "UQ__Applican__C93A4C98EFB4F738").IsUnique();

            entity.Property(e => e.AssignedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentStatusId).HasDefaultValue(1);
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.GitHubRepoUrl).HasMaxLength(200);
            entity.Property(e => e.LiveSiteUrl).HasMaxLength(200);
            entity.Property(e => e.SubmittedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Application).WithOne(p => p.ApplicantTestProject)
                .HasForeignKey<ApplicantTestProject>(d => d.ApplicationId)
                .HasConstraintName("FK__Applicant__Appli__02FC7413");

            entity.HasOne(d => d.CurrentStatus).WithMany(p => p.ApplicantTestProjects)
                .HasForeignKey(d => d.CurrentStatusId)
                .HasConstraintName("FK__Applicant__Curre__05D8E0BE");

            entity.HasOne(d => d.Template).WithMany(p => p.ApplicantTestProjects)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("FK__Applicant__Templ__03F0984C");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__C93A4C99EC1C900C");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Bio).HasMaxLength(500);
            entity.Property(e => e.Cgpa)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("CGPA");
            entity.Property(e => e.CoverLetter).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentStatusId).HasDefaultValue(1);
            entity.Property(e => e.CurrentYear).HasMaxLength(20);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.GitHubProfileLink).HasMaxLength(200);
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LeetCodeProfileLink).HasMaxLength(200);
            entity.Property(e => e.LinkedInProfileLink).HasMaxLength(200);
            entity.Property(e => e.Major).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PortfolioSiteLink).HasMaxLength(200);
            entity.Property(e => e.ResumePath).HasMaxLength(255);
            entity.Property(e => e.Skills).HasMaxLength(500);
            entity.Property(e => e.University).HasMaxLength(100);
            entity.Property(e => e.WillingToRelocate).HasDefaultValue(true);

            entity.HasOne(d => d.CurrentStatus).WithMany(p => p.Applications)
                .HasForeignKey(d => d.CurrentStatusId)
                .HasConstraintName("FK__Applicati__Curre__778AC167");

            entity.HasOne(d => d.User).WithMany(p => p.Applications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Applicati__UserI__76969D2E");
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Applicat__C8EE206397C8014D");

            entity.ToTable("ApplicationStatus");

            entity.HasIndex(e => e.StatusName, "UQ__Applicat__05E7698A6DC77E36").IsUnique();

            entity.Property(e => e.StatusName).HasMaxLength(20);
        });

        modelBuilder.Entity<Decision>(entity =>
        {
            entity.HasKey(e => e.DecisionId).HasName("PK__Decision__C0F289864B37D5D9");

            entity.ToTable(tb => tb.HasTrigger("UpdateApplicationStatusAfterDecision"));

            entity.Property(e => e.DecisionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.IsTestProjectAssigned).HasDefaultValue(false);
            entity.Property(e => e.TestProjectRequirements).HasMaxLength(1000);

            entity.HasOne(d => d.Admin).WithMany(p => p.Decisions)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__Decisions__Admin__0A9D95DB");

            entity.HasOne(d => d.Application).WithMany(p => p.Decisions)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__Decisions__Appli__09A971A2");

            entity.HasOne(d => d.NewStatus).WithMany(p => p.Decisions)
                .HasForeignKey(d => d.NewStatusId)
                .HasConstraintName("FK__Decisions__NewSt__0C85DE4D");
        });

        modelBuilder.Entity<TestProjectTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateId).HasName("PK__TestProj__F87ADD273582EA91");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.CreatedByAdmin).WithMany(p => p.TestProjectTemplates)
                .HasForeignKey(d => d.CreatedByAdminId)
                .HasConstraintName("FK__TestProje__Creat__7E37BEF6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CAA604415");

            entity.HasIndex(e => e.GivenName, "UQ__Users__79FA70BFC4EDC5F9").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E56301E2").IsUnique();

            entity.HasIndex(e => e.GrandFatherName, "UQ__Users__E2D003ED377B2DA0").IsUnique();

            entity.HasIndex(e => e.FatherName, "UQ__Users__FB20DD61EB8CE6E4").IsUnique();

            entity.Property(e => e.AccountCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.GivenName).HasMaxLength(50);
            entity.Property(e => e.GrandFatherName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.ProfilePicturePath).HasMaxLength(255);
            entity.Property(e => e.UserTypeId)
                .HasDefaultValue(1)
                .HasColumnName("UserTypeID");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK__Users__UserTypeI__71D1E811");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PK__UserType__FA6C4C3C5BADDEEC");

            entity.HasIndex(e => e.TypeName, "UQ__UserType__D4E7DFA8BBA5BFE9").IsUnique();

            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
