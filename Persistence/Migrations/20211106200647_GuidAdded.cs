using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class GuidAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Handle = table.Column<string>(type: "TEXT", nullable: true),
                    ProfileImage = table.Column<string>(type: "TEXT", nullable: true),
                    SubscriberCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Platform = table.Column<string>(type: "TEXT", nullable: true),
                    PlatformId = table.Column<string>(type: "TEXT", nullable: true),
                    AccountType = table.Column<string>(type: "TEXT", nullable: true),
                    PageAdminTopCountry = table.Column<string>(type: "TEXT", nullable: true),
                    PageDescription = table.Column<string>(type: "TEXT", nullable: true),
                    PageCreatedDate = table.Column<string>(type: "TEXT", nullable: true),
                    PageCategory = table.Column<string>(type: "TEXT", nullable: true),
                    Verified = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ShareCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LoveCount = table.Column<int>(type: "INTEGER", nullable: false),
                    WowCount = table.Column<int>(type: "INTEGER", nullable: false),
                    HahaCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SadCount = table.Column<int>(type: "INTEGER", nullable: false),
                    AngryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ThankfulCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CareCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expected",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ShareCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LoveCount = table.Column<int>(type: "INTEGER", nullable: false),
                    WowCount = table.Column<int>(type: "INTEGER", nullable: false),
                    HahaCount = table.Column<int>(type: "INTEGER", nullable: false),
                    SadCount = table.Column<int>(type: "INTEGER", nullable: false),
                    AngryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ThankfulCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CareCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expected", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActualId = table.Column<int>(type: "INTEGER", nullable: true),
                    ExpectedId = table.Column<int>(type: "INTEGER", nullable: true)
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
                name: "Posts",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlatformId = table.Column<string>(type: "TEXT", nullable: true),
                    Platform = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    Updated = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Caption = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    PostUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SubscriberCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<double>(type: "REAL", nullable: false),
                    StatisticsId = table.Column<int>(type: "INTEGER", nullable: true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    LanguageCode = table.Column<string>(type: "TEXT", nullable: true),
                    LegacyId = table.Column<int>(type: "INTEGER", nullable: true),
                    Id = table.Column<string>(type: "TEXT", nullable: true),
                    VideoLengthMS = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.GuidId);
                    table.ForeignKey(
                        name: "FK_Posts_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
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
                name: "ExpandedLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Original = table.Column<string>(type: "TEXT", nullable: true),
                    Expanded = table.Column<string>(type: "TEXT", nullable: true),
                    PostGuidId = table.Column<Guid>(type: "TEXT", nullable: true)
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
                name: "Medium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Full = table.Column<string>(type: "TEXT", nullable: true),
                    PostGuidId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medium_Posts_PostGuidId",
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
                name: "IX_Medium_PostGuidId",
                table: "Medium",
                column: "PostGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AccountId",
                table: "Posts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StatisticsId",
                table: "Posts",
                column: "StatisticsId");

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
                name: "Medium");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Actual");

            migrationBuilder.DropTable(
                name: "Expected");
        }
    }
}
