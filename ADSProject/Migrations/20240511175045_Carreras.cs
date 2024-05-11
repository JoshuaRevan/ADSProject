using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSProject.Migrations
{
    /// <inheritdoc />
    public partial class Carreras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", maxLength: 40, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.IdCarrera);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carreras");
        }
    }
}
