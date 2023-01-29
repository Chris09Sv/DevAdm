using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevControl.Migrations
{
    /// <inheritdoc />
    public partial class resolve15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "tbEstablecimientos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
