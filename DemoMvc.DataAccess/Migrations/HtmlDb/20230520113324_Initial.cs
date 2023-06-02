using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMVC.DataAccess.Migrations.HtmlDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    CSS_Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CSS_Class", "Icon", "ParentId", "Sequence", "Title", "URL" },
                values: new object[,]
                {
                    { 1, "", "", 0, 1, "Home", "/" },
                    { 2, "", "", 0, 2, "Content Management", "/" },
                    { 3, "", "", 2, 1, "Category", "/" },
                    { 4, "", "", 2, 2, "Cover Type", "/" },
                    { 5, "", "", 2, 3, "Product", "/" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
