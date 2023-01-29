using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevControl.Migrations
{
    /// <inheritdoc />
    public partial class resolve16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mun",
                table: "tbMunicipios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Nivel",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mun",
                table: "tbMunicipios");

            migrationBuilder.AlterColumn<int>(
                name: "Nivel",
                table: "tbEstablecimientos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
