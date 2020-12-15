using Microsoft.EntityFrameworkCore.Migrations;

namespace UDB.Data.Migrations
{
    public partial class Carreras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carrera = table.Column<string>(nullable: true),
                    Grado = table.Column<string>(nullable: true),
                    Duracion = table.Column<string>(nullable: true),
                    Campus = table.Column<string>(nullable: true),
                    Detalles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carreras");
        }
    }
}
