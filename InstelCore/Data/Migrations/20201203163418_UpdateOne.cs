using Microsoft.EntityFrameworkCore.Migrations;

namespace InstelCore.Data.Migrations
{
    public partial class UpdateOne : Migration
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

            migrationBuilder.CreateTable(
                name: "CategoryVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVM", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryVM");

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
