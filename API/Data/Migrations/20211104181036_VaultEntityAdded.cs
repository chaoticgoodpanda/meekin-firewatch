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

            migrationBuilder.AddColumn<int>(
                name: "VaultItemId",
                table: "Posts",
                type: "INTEGER",
                nullable: true);

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
                name: "VaultItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<string>(type: "TEXT", nullable: true),
                    VaultId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaultItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaultItems_Vaults_VaultId",
                        column: x => x.VaultId,
                        principalTable: "Vaults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VaultItemId",
                table: "Posts",
                column: "VaultItemId");

            migrationBuilder.CreateIndex(
                name: "IX_VaultItems_VaultId",
                table: "VaultItems",
                column: "VaultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_VaultItems_VaultItemId",
                table: "Posts",
                column: "VaultItemId",
                principalTable: "VaultItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_VaultItems_VaultItemId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "VaultItems");

            migrationBuilder.DropTable(
                name: "Vaults");

            migrationBuilder.DropIndex(
                name: "IX_Posts_VaultItemId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "VaultItemId",
                table: "Posts");

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
