using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UserImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45607bd3-4b72-41ae-a476-87991510ffdc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c377f67f-42d2-4020-9294-913e86e28412");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "600ef89e-3c66-4490-b084-a9abefe1f902", "ba5a697e-ed9a-4cbb-b974-ce796f267ef2", "Member", "MEMBER" },
                    { "258d46d9-36ec-4744-a32c-51662d1165c4", "6145c4f2-f7c5-4a00-926b-8aa39cf3e7ee", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "258d46d9-36ec-4744-a32c-51662d1165c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "600ef89e-3c66-4490-b084-a9abefe1f902");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c377f67f-42d2-4020-9294-913e86e28412", "4617c665-be77-4eb2-8bf7-6a229984e5e5", "Member", "MEMBER" },
                    { "45607bd3-4b72-41ae-a476-87991510ffdc", "1659981f-1d37-4961-a236-5688a9cc1c75", "Admin", "ADMIN" }
                });
        }
    }
}
