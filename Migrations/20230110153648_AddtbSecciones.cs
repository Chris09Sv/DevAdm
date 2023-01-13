using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevControl.Migrations
{
    /// <inheritdoc />
    public partial class AddtbSecciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Capacidad",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "tbSecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codonepr = table.Column<string>(name: "cod_one_pr", type: "nvarchar(max)", nullable: false),
                    codonemu = table.Column<string>(name: "cod_one_mu", type: "nvarchar(max)", nullable: false),
                    codonedm = table.Column<string>(name: "cod_one_dm", type: "nvarchar(max)", nullable: false),
                    codonese = table.Column<string>(name: "cod_one_se", type: "nvarchar(max)", nullable: false),
                    nombreone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbSecciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbSecciones");

            migrationBuilder.AlterColumn<int>(
                name: "Capacidad",
                table: "tbEstablecimientos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
