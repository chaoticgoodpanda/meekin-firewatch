using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
    public partial class TestPGInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Handle = table.Column<string>(type: "text", nullable: true),
                    ProfileImage = table.Column<string>(type: "text", nullable: true),
                    SubscriberCount = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Platform = table.Column<string>(type: "text", nullable: true),
                    PlatformId = table.Column<string>(type: "text", nullable: true),
                    AccountType = table.Column<string>(type: "text", nullable: true),
                    PageAdminTopCountry = table.Column<string>(type: "text", nullable: true),
                    PageDescription = table.Column<string>(type: "text", nullable: true),
                    PageCreatedDate = table.Column<string>(type: "text", nullable: true),
                    PageCategory = table.Column<string>(type: "text", nullable: true),
                    Verified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Actual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LikeCount = table.Column<int>(type: "integer", nullable: false),
                    ShareCount = table.Column<int>(type: "integer", nullable: false),
                    CommentCount = table.Column<int>(type: "integer", nullable: false),
                    LoveCount = table.Column<int>(type: "integer", nullable: false),
                    WowCount = table.Column<int>(type: "integer", nullable: false),
                    HahaCount = table.Column<int>(type: "integer", nullable: false),
                    SadCount = table.Column<int>(type: "integer", nullable: false),
                    AngryCount = table.Column<int>(type: "integer", nullable: false),
                    ThankfulCount = table.Column<int>(type: "integer", nullable: false),
                    CareCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expected",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LikeCount = table.Column<int>(type: "integer", nullable: false),
                    ShareCount = table.Column<int>(type: "integer", nullable: false),
                    CommentCount = table.Column<int>(type: "integer", nullable: false),
                    LoveCount = table.Column<int>(type: "integer", nullable: false),
                    WowCount = table.Column<int>(type: "integer", nullable: false),
                    HahaCount = table.Column<int>(type: "integer", nullable: false),
                    SadCount = table.Column<int>(type: "integer", nullable: false),
                    AngryCount = table.Column<int>(type: "integer", nullable: false),
                    ThankfulCount = table.Column<int>(type: "integer", nullable: false),
                    CareCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expected", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NextPage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostLabelings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    platformId = table.Column<string>(type: "text", nullable: true),
                    FacebookGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Speaker = table.Column<string>(type: "text", nullable: true),
                    SpeechContent = table.Column<string>(type: "text", nullable: true),
                    TranslatedSpeechContent = table.Column<string>(type: "text", nullable: true),
                    Justifications = table.Column<string[]>(type: "text[]", nullable: true),
                    Intent = table.Column<int>(type: "integer", nullable: true),
                    RabatLikelihoodHarm = table.Column<double>(type: "double precision", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    HumanTarget = table.Column<bool>(type: "boolean", nullable: false),
                    FacebookDecision = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<string>(type: "text", nullable: true),
                    DecisionDate = table.Column<string>(type: "text", nullable: true),
                    AnalysisReport = table.Column<string>(type: "text", nullable: true),
                    SummaryAnalysis = table.Column<string>(type: "text", nullable: true),
                    AnalysisDate = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLabelings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActualId = table.Column<int>(type: "integer", nullable: true),
                    ExpectedId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Actual_ActualId",
                        column: x => x.ActualId,
                        principalTable: "Actual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistics_Expected_ExpectedId",
                        column: x => x.ExpectedId,
                        principalTable: "Expected",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaginationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Pagination_PaginationId",
                        column: x => x.PaginationId,
                        principalTable: "Pagination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformId = table.Column<string>(type: "text", nullable: true),
                    Platform = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Updated = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Caption = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    PostUrl = table.Column<string>(type: "text", nullable: true),
                    SubscriberCount = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: false),
                    StatisticsId = table.Column<int>(type: "integer", nullable: true),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    LanguageCode = table.Column<string>(type: "text", nullable: true),
                    LegacyId = table.Column<int>(type: "integer", nullable: true),
                    Id = table.Column<string>(type: "text", nullable: true),
                    VideoLengthMS = table.Column<int>(type: "integer", nullable: true),
                    ResultId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.GuidId);
                    table.ForeignKey(
                        name: "FK_Posts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Result",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Statistics_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    RootId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ResultId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.RootId);
                    table.ForeignKey(
                        name: "FK_Roots_Result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Result",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpandedLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Original = table.Column<string>(type: "text", nullable: true),
                    Expanded = table.Column<string>(type: "text", nullable: true),
                    PostGuidId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpandedLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpandedLink_Posts_PostGuidId",
                        column: x => x.PostGuidId,
                        principalTable: "Posts",
                        principalColumn: "GuidId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Full = table.Column<string>(type: "text", nullable: true),
                    PostGuidId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Posts_PostGuidId",
                        column: x => x.PostGuidId,
                        principalTable: "Posts",
                        principalColumn: "GuidId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpandedLink_PostGuidId",
                table: "ExpandedLink",
                column: "PostGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_PostGuidId",
                table: "Media",
                column: "PostGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AccountId",
                table: "Posts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ResultId",
                table: "Posts",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StatisticsId",
                table: "Posts",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_PaginationId",
                table: "Result",
                column: "PaginationId");

            migrationBuilder.CreateIndex(
                name: "IX_Roots_ResultId",
                table: "Roots",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_ActualId",
                table: "Statistics",
                column: "ActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_ExpectedId",
                table: "Statistics",
                column: "ExpectedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpandedLink");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "PostLabelings");

            migrationBuilder.DropTable(
                name: "Roots");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Pagination");

            migrationBuilder.DropTable(
                name: "Actual");

            migrationBuilder.DropTable(
                name: "Expected");
        }
    }
}
