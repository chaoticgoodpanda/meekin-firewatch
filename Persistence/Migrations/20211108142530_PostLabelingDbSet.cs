using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PostLabelingDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostLabelings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    PostId = table.Column<int>(type: "INTEGER", nullable: true),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    Speaker = table.Column<int>(type: "INTEGER", nullable: false),
                    Offensive = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDangerous = table.Column<bool>(type: "INTEGER", nullable: true),
                    Justifications = table.Column<int>(type: "INTEGER", nullable: true),
                    RabatVirality = table.Column<long>(type: "INTEGER", nullable: false),
                    Intent = table.Column<int>(type: "INTEGER", nullable: true),
                    RabatLikelihoodHarm = table.Column<double>(type: "REAL", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    OffensiveContent = table.Column<bool>(type: "INTEGER", nullable: false),
                    HumanTarget = table.Column<bool>(type: "INTEGER", nullable: false),
                    FacebookDecision = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AccessTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AnalysisReport = table.Column<string>(type: "TEXT", nullable: true),
                    SummaryAnalysis = table.Column<string>(type: "TEXT", nullable: true),
                    AnalysisDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLabelings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostLabelings");
        }
    }
}
