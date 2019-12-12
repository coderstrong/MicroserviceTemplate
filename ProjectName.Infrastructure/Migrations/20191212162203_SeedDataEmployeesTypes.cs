using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectName.Infrastructure.Migrations
{
    public partial class SeedDataEmployeesTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "1", "internship"});
            migrationBuilder.InsertData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "2", "fresher"});
            migrationBuilder.InsertData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "3", "junior"});
            migrationBuilder.InsertData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "4", "senior"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "1", "internship"});
            migrationBuilder.DeleteData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "2", "fresher"});
            migrationBuilder.DeleteData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "3", "junior"});
            migrationBuilder.DeleteData("EmployeesTypes", new string[] { "Id", "Name"}, new string[] { "4", "senior"});
        }
    }
}
