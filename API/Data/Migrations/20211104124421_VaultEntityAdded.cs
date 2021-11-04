﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class VaultEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LegacyId",
                table: "Posts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Post",
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
                    PageCreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PageCategory = table.Column<string>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<long>(type: "INTEGER", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<int>(type: "INTEGER", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: true),
                    Full = table.Column<string>(type: "TEXT", nullable: true),
                    Accesstime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PostId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Post_PostId1",
                        column: x => x.PostId1,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostLabeling",
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
                    table.PrimaryKey("PK_PostLabeling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostLabeling_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VaultItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    VaultId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaultItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaultItems_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaultItems_Vaults_VaultId",
                        column: x => x.VaultId,
                        principalTable: "Vaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_PostId1",
                table: "Media",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_PostLabeling_PostId",
                table: "PostLabeling",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_VaultItems_PostId",
                table: "VaultItems",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_VaultItems_VaultId",
                table: "VaultItems",
                column: "VaultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "PostLabeling");

            migrationBuilder.DropTable(
                name: "VaultItems");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Vaults");

            migrationBuilder.AlterColumn<int>(
                name: "LegacyId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
