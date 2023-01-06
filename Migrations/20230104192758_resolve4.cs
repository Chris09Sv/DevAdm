using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevControl.Migrations
{
    /// <inheritdoc />
    public partial class resolve4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdViepi",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Laboratorio",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "prueba",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sat",
                table: "tbEstablecimientos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdViepi",
                table: "tbEstablecimientos");

            migrationBuilder.DropColumn(
                name: "Laboratorio",
                table: "tbEstablecimientos");

            migrationBuilder.DropColumn(
                name: "prueba",
                table: "tbEstablecimientos");

            migrationBuilder.DropColumn(
                name: "sat",
                table: "tbEstablecimientos");
        }
    }
}
