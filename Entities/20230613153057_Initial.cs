using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Entities
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clients_pkey", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    skill_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    profession_area = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("skills_pkey", x => x.skill_id);
                });

            migrationBuilder.CreateTable(
                name: "talents",
                columns: table => new
                {
                    talent_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    hourly_rate = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    is_public = table.Column<BitArray>(type: "bit(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("talents_pkey", x => x.talent_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "clienttalents",
                columns: table => new
                {
                    client_talent_id = table.Column<int>(type: "integer", nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: true),
                    talent_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clienttalents_pkey", x => x.client_talent_id);
                    table.ForeignKey(
                        name: "clienttalents_client_id_fkey",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "client_id");
                    table.ForeignKey(
                        name: "clienttalents_talent_id_fkey",
                        column: x => x.talent_id,
                        principalTable: "talents",
                        principalColumn: "talent_id");
                });

            migrationBuilder.CreateTable(
                name: "experiences",
                columns: table => new
                {
                    experience_id = table.Column<int>(type: "integer", nullable: false),
                    talent_id = table.Column<int>(type: "integer", nullable: true),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    company_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    start_year = table.Column<int>(type: "integer", nullable: true),
                    end_year = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("experiences_pkey", x => x.experience_id);
                    table.ForeignKey(
                        name: "experiences_talent_id_fkey",
                        column: x => x.talent_id,
                        principalTable: "talents",
                        principalColumn: "talent_id");
                });

            migrationBuilder.CreateTable(
                name: "userskills",
                columns: table => new
                {
                    user_skill_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    skill_id = table.Column<int>(type: "integer", nullable: true),
                    years_of_experience = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("userskills_pkey", x => x.user_skill_id);
                    table.ForeignKey(
                        name: "userskills_skill_id_fkey",
                        column: x => x.skill_id,
                        principalTable: "skills",
                        principalColumn: "skill_id");
                    table.ForeignKey(
                        name: "userskills_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "workproposals",
                columns: table => new
                {
                    proposal_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    client_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    talent_category = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    skills_required = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    min_years_of_experience = table.Column<int>(type: "integer", nullable: true),
                    total_hours = table.Column<int>(type: "integer", nullable: true),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("workproposals_pkey", x => x.proposal_id);
                    table.ForeignKey(
                        name: "workproposals_client_id_fkey",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "client_id");
                    table.ForeignKey(
                        name: "workproposals_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_clienttalents_client_id",
                table: "clienttalents",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_clienttalents_talent_id",
                table: "clienttalents",
                column: "talent_id");

            migrationBuilder.CreateIndex(
                name: "IX_experiences_talent_id",
                table: "experiences",
                column: "talent_id");

            migrationBuilder.CreateIndex(
                name: "IX_userskills_skill_id",
                table: "userskills",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_userskills_user_id",
                table: "userskills",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_workproposals_client_id",
                table: "workproposals",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_workproposals_user_id",
                table: "workproposals",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clienttalents");

            migrationBuilder.DropTable(
                name: "experiences");

            migrationBuilder.DropTable(
                name: "userskills");

            migrationBuilder.DropTable(
                name: "workproposals");

            migrationBuilder.DropTable(
                name: "talents");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
