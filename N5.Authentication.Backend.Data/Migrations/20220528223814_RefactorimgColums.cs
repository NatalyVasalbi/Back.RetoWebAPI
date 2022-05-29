using Microsoft.EntityFrameworkCore.Migrations;

namespace N5.Authentication.Backend.Data.Migrations
{
    public partial class RefactorimgColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeSurname",
                table: "Permissions",
                newName: "EmployeeName");

            migrationBuilder.RenameColumn(
                name: "EmployeeForename",
                table: "Permissions",
                newName: "EmployeeLastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Permissions",
                newName: "EmployeeSurname");

            migrationBuilder.RenameColumn(
                name: "EmployeeLastName",
                table: "Permissions",
                newName: "EmployeeForename");
        }
    }
}
