using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POCF1.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(30)", nullable: false),
                    PotenciaCarro = table.Column<int>(type: "int", nullable: false),
                    AerodinamicaCarro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    EquipeId = table.Column<int>(nullable: false),
                    NivelExperiencia = table.Column<int>(type: "int", nullable: false),
                    QuantidadeParadas = table.Column<int>(type: "int", nullable: false),
                    PosicaoLargada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pilotos_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeCircuito = table.Column<string>(type: "varchar(30)", nullable: false),
                    TrajetoTotalCircuito = table.Column<int>(nullable: false),
                    DataCorrida = table.Column<DateTime>(nullable: false),
                    Piloto1Id = table.Column<int>(nullable: true),
                    Tempo1 = table.Column<TimeSpan>(nullable: true),
                    Piloto2Id = table.Column<int>(nullable: true),
                    Tempo2 = table.Column<TimeSpan>(nullable: true),
                    Piloto3Id = table.Column<int>(nullable: true),
                    Tempo3 = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Corridas_Pilotos_Piloto1Id",
                        column: x => x.Piloto1Id,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Corridas_Pilotos_Piloto2Id",
                        column: x => x.Piloto2Id,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Corridas_Pilotos_Piloto3Id",
                        column: x => x.Piloto3Id,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_Piloto1Id",
                table: "Corridas",
                column: "Piloto1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_Piloto2Id",
                table: "Corridas",
                column: "Piloto2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_Piloto3Id",
                table: "Corridas",
                column: "Piloto3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pilotos_EquipeId",
                table: "Pilotos",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Pilotos");

            migrationBuilder.DropTable(
                name: "Equipes");
        }
    }
}
