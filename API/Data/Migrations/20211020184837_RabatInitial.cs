using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class RabatInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostLabels",
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
                    table.PrimaryKey("PK_PostLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountName = table.Column<string>(type: "TEXT", nullable: true),
                    PostContent = table.Column<string>(type: "TEXT", nullable: true),
                    ProfileImage = table.Column<string>(type: "TEXT", nullable: true),
                    SocialMediaPlatform = table.Column<string>(type: "TEXT", nullable: true),
                    SocialMediaPlatformId = table.Column<long>(type: "INTEGER", nullable: false),
                    AccountType = table.Column<string>(type: "TEXT", nullable: true),
                    AccountCountry = table.Column<string>(type: "TEXT", nullable: true),
                    Verified = table.Column<bool>(type: "INTEGER", nullable: false),
                    PostUrl = table.Column<string>(type: "TEXT", nullable: true),
                    MediaUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ImageText = table.Column<string>(type: "TEXT", nullable: true),
                    SubscriberCount = table.Column<long>(type: "INTEGER", nullable: false),
                    Score = table.Column<double>(type: "REAL", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    PostCreationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CrowdtangleUpdateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AccessTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExternalLink = table.Column<string>(type: "TEXT", nullable: true),
                    LinkCaption = table.Column<string>(type: "TEXT", nullable: true),
                    LinkTitle = table.Column<string>(type: "TEXT", nullable: true),
                    LinkDescription = table.Column<string>(type: "TEXT", nullable: true),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: true),
                    ShareCount = table.Column<int>(type: "INTEGER", nullable: true),
                    CommentCount = table.Column<int>(type: "INTEGER", nullable: true),
                    LoveCount = table.Column<int>(type: "INTEGER", nullable: true),
                    WowCount = table.Column<int>(type: "INTEGER", nullable: true),
                    HahaCount = table.Column<int>(type: "INTEGER", nullable: true),
                    SadCount = table.Column<int>(type: "INTEGER", nullable: true),
                    AngryCount = table.Column<int>(type: "INTEGER", nullable: true),
                    ThankfulCount = table.Column<int>(type: "INTEGER", nullable: true),
                    CareCount = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostLabels");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
