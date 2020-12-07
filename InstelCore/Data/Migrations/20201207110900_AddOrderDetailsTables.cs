using Microsoft.EntityFrameworkCore.Migrations;

namespace InstelCore.Data.Migrations
{
    public partial class AddOrderDetailsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Co_Logos",
                table: "Co_Logos");

            migrationBuilder.RenameTable(
                name: "Co_Logos",
                newName: "CoLogos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoLogos",
                table: "CoLogos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoLogos",
                table: "CoLogos");

            migrationBuilder.RenameTable(
                name: "CoLogos",
                newName: "Co_Logos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Co_Logos",
                table: "Co_Logos",
                column: "Id");
        }
    }
}
