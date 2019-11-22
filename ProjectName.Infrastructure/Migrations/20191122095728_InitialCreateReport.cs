using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ProjectName.Infrastructure.Migrations
{
    public partial class InitialCreateReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 20, nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    ContractTypeId = table.Column<int>(nullable: true),
                    ContractType = table.Column<string>(maxLength: 255, nullable: true),
                    ContractTypeCode = table.Column<string>(maxLength: 20, nullable: true),
                    EmployeerId = table.Column<int>(nullable: true),
                    EmployeerName = table.Column<string>(maxLength: 255, nullable: true),
                    Salary = table.Column<float>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true),
                    SignDate = table.Column<DateTime>(nullable: true),
                    ContractNo = table.Column<string>(maxLength: 20, nullable: true),
                    SignId = table.Column<int>(nullable: true),
                    SignCode = table.Column<string>(maxLength: 20, nullable: true),
                    SignName = table.Column<string>(maxLength: 255, nullable: true),
                    SignOrg = table.Column<string>(maxLength: 255, nullable: true),
                    SignPos = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    WorkingTime = table.Column<string>(maxLength: 512, nullable: true),
                    Note = table.Column<string>(maxLength: 512, nullable: true),
                    Index = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    DeletedBy = table.Column<string>(maxLength: 20, nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}