using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;

namespace WebApplication2.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clienttalent> Clienttalents { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Talent> Talents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userskill> Userskills { get; set; }

    public virtual DbSet<Workproposal> Workproposals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=es2;Username=es2;Password=es2;SearchPath=public;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("client_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Clienttalent>(entity =>
        {
            entity.HasKey(e => e.ClientTalentId).HasName("clienttalents_pkey");

            entity.ToTable("clienttalents");

            entity.Property(e => e.ClientTalentId)
                .ValueGeneratedNever()
                .HasColumnName("client_talent_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.TalentId).HasColumnName("talent_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Clienttalents)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("clienttalents_client_id_fkey");

            entity.HasOne(d => d.Talent).WithMany(p => p.Clienttalents)
                .HasForeignKey(d => d.TalentId)
                .HasConstraintName("clienttalents_talent_id_fkey");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperienceId).HasName("experiences_pkey");

            entity.ToTable("experiences");

            entity.Property(e => e.ExperienceId)
                .ValueGeneratedNever()
                .HasColumnName("experience_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.EndYear).HasColumnName("end_year");
            entity.Property(e => e.StartYear).HasColumnName("start_year");
            entity.Property(e => e.TalentId).HasColumnName("talent_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Talent).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.TalentId)
                .HasConstraintName("experiences_talent_id_fkey");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("skills_pkey");

            entity.ToTable("skills");

            entity.Property(e => e.SkillId)
                .ValueGeneratedNever()
                .HasColumnName("skill_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.ProfessionArea)
                .HasMaxLength(255)
                .HasColumnName("profession_area");
        });

        modelBuilder.Entity<Talent>(entity =>
        {
            entity.HasKey(e => e.TalentId).HasName("talents_pkey");

            entity.ToTable("talents");

            entity.Property(e => e.TalentId)
                .ValueGeneratedNever()
                .HasColumnName("talent_id");
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HourlyRate)
                .HasPrecision(10, 2)
                .HasColumnName("hourly_rate");
            entity.Property(e => e.IsPublic)
                .HasColumnType("bit(1)")
                .HasColumnName("is_public");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Userskill>(entity =>
        {
            entity.HasKey(e => e.UserSkillId).HasName("userskills_pkey");

            entity.ToTable("userskills");

            entity.Property(e => e.UserSkillId)
                .ValueGeneratedNever()
                .HasColumnName("user_skill_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.YearsOfExperience).HasColumnName("years_of_experience");

            entity.HasOne(d => d.Skill).WithMany(p => p.Userskills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("userskills_skill_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Userskills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userskills_user_id_fkey");
        });

        modelBuilder.Entity<Workproposal>(entity =>
        {
            entity.HasKey(e => e.ProposalId).HasName("workproposals_pkey");

            entity.ToTable("workproposals");

            entity.Property(e => e.ProposalId)
                .ValueGeneratedNever()
                .HasColumnName("proposal_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.MinYearsOfExperience).HasColumnName("min_years_of_experience");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.SkillsRequired)
                .HasMaxLength(255)
                .HasColumnName("skills_required");
            entity.Property(e => e.TalentCategory)
                .HasMaxLength(255)
                .HasColumnName("talent_category");
            entity.Property(e => e.TotalHours).HasColumnName("total_hours");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Workproposals)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("workproposals_client_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Workproposals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("workproposals_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
