using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevControl.Migrations
{
    /// <inheritdoc />
    public partial class resolve6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sat",
                table: "tbEstablecimientos",
                newName: "Sat");

            migrationBuilder.AlterColumn<int>(
                name: "Sector",
                table: "tbEstablecimientos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdViepi",
                table: "tbEstablecimientos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Capacidad",
                table: "tbEstablecimientos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "tbEstablecimientos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "vmEstablecimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Centro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subsector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prueba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viepi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vmEstablecimientos", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vmEstablecimientos");

            migrationBuilder.RenameColumn(
                name: "Sat",
                table: "tbEstablecimientos",
                newName: "sat");

            migrationBuilder.AlterColumn<int>(
                name: "Sector",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdViepi",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacidad",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "tbEstablecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
