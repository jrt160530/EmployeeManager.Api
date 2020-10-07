using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Api.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Countries",
                newName: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "Countries",
                newName: "CountryId");
        }
    }
}
