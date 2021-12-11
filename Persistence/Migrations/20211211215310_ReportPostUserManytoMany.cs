using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ReportPostUserManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aec4f46-d474-4517-828b-d011e8611484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88a8a3b8-ecb9-48ae-8875-3db7a7c60daf");

            migrationBuilder.CreateTable(
                name: "PostFollowers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPoster = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostFollowers", x => new { x.UserId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostFollowers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostFollowers_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "GuidId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportReporters",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAuthor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportReporters", x => new { x.UserId, x.ReportId });
                    table.ForeignKey(
                        name: "FK_ReportReporters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportReporters_PostLabelings_ReportId",
                        column: x => x.ReportId,
                        principalTable: "PostLabelings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c377f67f-42d2-4020-9294-913e86e28412", "4617c665-be77-4eb2-8bf7-6a229984e5e5", "Member", "MEMBER" },
                    { "45607bd3-4b72-41ae-a476-87991510ffdc", "1659981f-1d37-4961-a236-5688a9cc1c75", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostFollowers_PostId",
                table: "PostFollowers",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportReporters_ReportId",
                table: "ReportReporters",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostFollowers");

            migrationBuilder.DropTable(
                name: "ReportReporters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45607bd3-4b72-41ae-a476-87991510ffdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c377f67f-42d2-4020-9294-913e86e28412");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88a8a3b8-ecb9-48ae-8875-3db7a7c60daf", "03534765-bd04-41aa-9768-c75a4d26d2ec", "Member", "MEMBER" },
                    { "2aec4f46-d474-4517-828b-d011e8611484", "c9b151cc-6419-4652-9506-4ac682642b4e", "Admin", "ADMIN" }
                });
        }
    }
}
