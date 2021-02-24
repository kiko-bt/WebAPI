using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building = table.Column<string>(maxLength: 250, nullable: false),
                    RestAPI = table.Column<string>(maxLength: 250, nullable: false),
                    Project = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "Building", "Project", "RestAPI" },
                values: new object[] { 1, "WebApplication Project", "Commander Project", "Representational State Transfer Application Interface" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");
        }
    }
}
