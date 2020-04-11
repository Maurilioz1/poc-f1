using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POCF1.Data.Migrations
{
    public partial class AddCorrida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCircuito = table.Column<string>(type: "varchar(30)", nullable: false),
                    TrajetoTotalCircuito = table.Column<int>(type: "int", nullable: false),
                    DataCorrida = table.Column<DateTime>(type: "datetime", nullable: false),
                    Piloto1 = table.Column<int>(type: "int", nullable: false),
                    Tempo1 = table.Column<DateTime>(type: "datetime", nullable: false),
                    Piloto2 = table.Column<int>(type: "int", nullable: false),
                    Tempo2 = table.Column<DateTime>(type: "datetime", nullable: false),
                    Piloto3 = table.Column<int>(type: "int", nullable: false),
                    Tempo3 = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corridas");
        }
    }
}
