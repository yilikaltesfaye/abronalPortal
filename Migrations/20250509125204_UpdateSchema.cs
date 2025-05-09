using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abronalPortal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Applicat__C8EE206397C8014D", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserType__FA6C4C3C5BADDEEC", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GivenName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrandFatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountCreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UserTypeID = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4CAA604415", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__Users__UserTypeI__71D1E811",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CurrentStatusId = table.Column<int>(type: "int", nullable: true, defaultValue: 1),
                    Designation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WillingToRelocate = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    University = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CurrentYear = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CGPA = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Major = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ResumePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GitHubProfileLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LinkedInProfileLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LeetCodeProfileLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PortfolioSiteLink = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PastProjectsJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverLetter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Applicat__C93A4C99EC1C900C", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK__Applicati__Curre__778AC167",
                        column: x => x.CurrentStatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK__Applicati__UserI__76969D2E",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TestProjectTemplates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologiesToUse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionalLibraries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByAdminId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TestProj__F87ADD273582EA91", x => x.TemplateId);
                    table.ForeignKey(
                        name: "FK__TestProje__Creat__7E37BEF6",
                        column: x => x.CreatedByAdminId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    DecisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NewStatusId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsTestProjectAssigned = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    TestProjectRequirements = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Decision__C0F289864B37D5D9", x => x.DecisionId);
                    table.ForeignKey(
                        name: "FK__Decisions__Admin__0A9D95DB",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK__Decisions__Appli__09A971A2",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId");
                    table.ForeignKey(
                        name: "FK__Decisions__NewSt__0C85DE4D",
                        column: x => x.NewStatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "ApplicantTestProjects",
                columns: table => new
                {
                    ApplicantTestProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CustomFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionalLibraries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Deadline = table.Column<DateTime>(type: "datetime", nullable: true),
                    GitHubRepoUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LiveSiteUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubmittedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CurrentStatusId = table.Column<int>(type: "int", nullable: true, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Applican__7D28F6B2616F8143", x => x.ApplicantTestProjectId);
                    table.ForeignKey(
                        name: "FK__Applicant__Appli__02FC7413",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId");
                    table.ForeignKey(
                        name: "FK__Applicant__Curre__05D8E0BE",
                        column: x => x.CurrentStatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK__Applicant__Templ__03F0984C",
                        column: x => x.TemplateId,
                        principalTable: "TestProjectTemplates",
                        principalColumn: "TemplateId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTestProjects_CurrentStatusId",
                table: "ApplicantTestProjects",
                column: "CurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTestProjects_TemplateId",
                table: "ApplicantTestProjects",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "UQ__Applican__C93A4C98EFB4F738",
                table: "ApplicantTestProjects",
                column: "ApplicationId",
                unique: true,
                filter: "[ApplicationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CurrentStatusId",
                table: "Applications",
                column: "CurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ__Applicat__05E7698A6DC77E36",
                table: "ApplicationStatus",
                column: "StatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_AdminId",
                table: "Decisions",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_ApplicationId",
                table: "Decisions",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_NewStatusId",
                table: "Decisions",
                column: "NewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TestProjectTemplates_CreatedByAdminId",
                table: "TestProjectTemplates",
                column: "CreatedByAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__79FA70BFC4EDC5F9",
                table: "Users",
                column: "GivenName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534E56301E2",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__E2D003ED377B2DA0",
                table: "Users",
                column: "GrandFatherName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__FB20DD61EB8CE6E4",
                table: "Users",
                column: "FatherName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__UserType__D4E7DFA8BBA5BFE9",
                table: "UserTypes",
                column: "TypeName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantTestProjects");

            migrationBuilder.DropTable(
                name: "Decisions");

            migrationBuilder.DropTable(
                name: "TestProjectTemplates");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
