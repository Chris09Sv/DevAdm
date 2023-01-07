using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevControl.Migrations
{
    /// <inheritdoc />
    public partial class resolve8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vmEstablecimientos");

            migrationBuilder.CreateTable(
                name: "tbCapacidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCapacidad", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbCapacidad");

            migrationBuilder.CreateTable(
                name: "vmEstablecimientos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Centro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Laboratorio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subsector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viepi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prueba = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vmEstablecimientos", x => x.id);
                });
        }
    }
}
