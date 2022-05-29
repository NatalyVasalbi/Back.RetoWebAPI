using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace N5.Authentication.Backend.Data.Migrations
{
    public partial class AuditoriaColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "PermissionTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "PermissionTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "PermissionTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "PermissionTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Permissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Permissions",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "PermissionTypes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "PermissionTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "PermissionTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "PermissionTypes");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Permissions");
        }
    }
}
