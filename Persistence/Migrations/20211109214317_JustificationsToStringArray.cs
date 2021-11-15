using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class JustificationsToStringArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDangerous",
                table: "PostLabelings");

            migrationBuilder.DropColumn(
                name: "Justifications",
                table: "PostLabelings");

            migrationBuilder.DropColumn(
                name: "Offensive",
                table: "PostLabelings");

            migrationBuilder.DropColumn(
                name: "OffensiveContent",
                table: "PostLabelings");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostLabelings");

            migrationBuilder.RenameColumn(
                name: "AccessTime",
                table: "PostLabelings",
                newName: "SpeechContent");

            migrationBuilder.CreateTable(
                name: "Justifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Justification = table.Column<string>(type: "TEXT", nullable: true),
                    PostLabelingId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Justifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Justifications_PostLabelings_PostLabelingId",
                        column: x => x.PostLabelingId,
                        principalTable: "PostLabelings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Justifications_PostLabelingId",
                table: "Justifications",
                column: "PostLabelingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Justifications");

            migrationBuilder.RenameColumn(
                name: "SpeechContent",
                table: "PostLabelings",
                newName: "AccessTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsDangerous",
                table: "PostLabelings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Justifications",
                table: "PostLabelings",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Offensive",
                table: "PostLabelings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OffensiveContent",
                table: "PostLabelings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "PostLabelings",
                type: "INTEGER",
                nullable: true);
        }
    }
}
