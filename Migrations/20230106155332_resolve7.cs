using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevControl.Migrations
{
    /// <inheritdoc />
    public partial class resolve7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Activacion",
                table: "tbEstablecimientos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Creacion",
                table: "tbEstablecimientos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "InActivacion",
                table: "tbEstablecimientos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Usuario",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activacion",
                table: "tbEstablecimientos");

            migrationBuilder.DropColumn(
                name: "Creacion",
                table: "tbEstablecimientos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "tbEstablecimientos");

            migrationBuilder.DropColumn(
                name: "InActivacion",
                table: "tbEstablecimientos");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "tbEstablecimientos");
        }
    }
}
