using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication2.Context;

#nullable disable

namespace WebApplication2.Entities
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("ClientId")
                        .HasName("clients_pkey");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.Clienttalent", b =>
                {
                    b.Property<int>("ClientTalentId")
                        .HasColumnType("integer")
                        .HasColumnName("client_talent_id");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<int?>("TalentId")
                        .HasColumnType("integer")
                        .HasColumnName("talent_id");

                    b.HasKey("ClientTalentId")
                        .HasName("clienttalents_pkey");

                    b.HasIndex("ClientId");

                    b.HasIndex("TalentId");

                    b.ToTable("clienttalents", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .HasColumnType("integer")
                        .HasColumnName("experience_id");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("company_name");

                    b.Property<int?>("EndYear")
                        .HasColumnType("integer")
                        .HasColumnName("end_year");

                    b.Property<int?>("StartYear")
                        .HasColumnType("integer")
                        .HasColumnName("start_year");

                    b.Property<int?>("TalentId")
                        .HasColumnType("integer")
                        .HasColumnName("talent_id");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.HasKey("ExperienceId")
                        .HasName("experiences_pkey");

                    b.HasIndex("TalentId");

                    b.ToTable("experiences", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.Skill", b =>
                {
                    b.Property<int>("SkillId")
                        .HasColumnType("integer")
                        .HasColumnName("skill_id");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("ProfessionArea")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("profession_area");

                    b.HasKey("SkillId")
                        .HasName("skills_pkey");

                    b.ToTable("skills", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.Talent", b =>
                {
                    b.Property<int>("TalentId")
                        .HasColumnType("integer")
                        .HasColumnName("talent_id");

                    b.Property<string>("Country")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("country");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<decimal?>("HourlyRate")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("hourly_rate");

                    b.Property<BitArray>("IsPublic")
                        .HasColumnType("bit(1)")
                        .HasColumnName("is_public");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.HasKey("TalentId")
                        .HasName("talents_pkey");

                    b.ToTable("talents", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("users_pkey");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.Userskill", b =>
                {
                    b.Property<int>("UserSkillId")
                        .HasColumnType("integer")
                        .HasColumnName("user_skill_id");

                    b.Property<int?>("SkillId")
                        .HasColumnType("integer")
                        .HasColumnName("skill_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int?>("YearsOfExperience")
                        .HasColumnType("integer")
                        .HasColumnName("years_of_experience");

                    b.HasKey("UserSkillId")
                        .HasName("userskills_pkey");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("userskills", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.Workproposal", b =>
                {
                    b.Property<int>("ProposalId")
                        .HasColumnType("integer")
                        .HasColumnName("proposal_id");

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<int?>("MinYearsOfExperience")
                        .HasColumnType("integer")
                        .HasColumnName("min_years_of_experience");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<string>("SkillsRequired")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("skills_required");

                    b.Property<string>("TalentCategory")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("talent_category");

                    b.Property<int?>("TotalHours")
                        .HasColumnType("integer")
                        .HasColumnName("total_hours");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("ProposalId")
                        .HasName("workproposals_pkey");

                    b.HasIndex("ClientId");

                    b.HasIndex("UserId");

                    b.ToTable("workproposals", (string)null);
                });

            modelBuilder.Entity("WebApplication2.Entities.Clienttalent", b =>
                {
                    b.HasOne("WebApplication2.Entities.Client", "Client")
                        .WithMany("Clienttalents")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("clienttalents_client_id_fkey");

                    b.HasOne("WebApplication2.Entities.Talent", "Talent")
                        .WithMany("Clienttalents")
                        .HasForeignKey("TalentId")
                        .HasConstraintName("clienttalents_talent_id_fkey");

                    b.Navigation("Client");

                    b.Navigation("Talent");
                });

            modelBuilder.Entity("WebApplication2.Entities.Experience", b =>
                {
                    b.HasOne("WebApplication2.Entities.Talent", "Talent")
                        .WithMany("Experiences")
                        .HasForeignKey("TalentId")
                        .HasConstraintName("experiences_talent_id_fkey");

                    b.Navigation("Talent");
                });

            modelBuilder.Entity("WebApplication2.Entities.Userskill", b =>
                {
                    b.HasOne("WebApplication2.Entities.Skill", "Skill")
                        .WithMany("Userskills")
                        .HasForeignKey("SkillId")
                        .HasConstraintName("userskills_skill_id_fkey");

                    b.HasOne("WebApplication2.Entities.User", "User")
                        .WithMany("Userskills")
                        .HasForeignKey("UserId")
                        .HasConstraintName("userskills_user_id_fkey");

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication2.Entities.Workproposal", b =>
                {
                    b.HasOne("WebApplication2.Entities.Client", "Client")
                        .WithMany("Workproposals")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("workproposals_client_id_fkey");

                    b.HasOne("WebApplication2.Entities.User", "User")
                        .WithMany("Workproposals")
                        .HasForeignKey("UserId")
                        .HasConstraintName("workproposals_user_id_fkey");

                    b.Navigation("Client");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication2.Entities.Client", b =>
                {
                    b.Navigation("Clienttalents");

                    b.Navigation("Workproposals");
                });

            modelBuilder.Entity("WebApplication2.Entities.Skill", b =>
                {
                    b.Navigation("Userskills");
                });

            modelBuilder.Entity("WebApplication2.Entities.Talent", b =>
                {
                    b.Navigation("Clienttalents");

                    b.Navigation("Experiences");
                });

            modelBuilder.Entity("WebApplication2.Entities.User", b =>
                {
                    b.Navigation("Userskills");

                    b.Navigation("Workproposals");
                });
#pragma warning restore 612, 618
        }
    }
}
