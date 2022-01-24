using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace acme_employees.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemUserId = table.Column<int>(type: "int", nullable: false),
                    EmployeeNum = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    EmployedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TerminatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "SystemUser",
                columns: table => new
                {
                    SystemUserId = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUser", x => x.SystemUserId);
                    table.ForeignKey(
                        name: "FK__Employee__System__30F848ED",
                        column: x => x.SystemUserId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemUser");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
