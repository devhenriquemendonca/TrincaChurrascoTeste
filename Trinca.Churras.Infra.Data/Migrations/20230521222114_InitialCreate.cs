using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trinca.Churras.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Churrasco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataComemorativa = table.Column<DateTime>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    ObservacaoAdicional = table.Column<string>(type: "varchar(100)", nullable: true),
                    ValorSugeridoPorPessoa = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAdicionalBebida = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churrasco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChurrascoParticipante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChurrascoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(100)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurrascoParticipante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChurrascoParticipante_Churrasco_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrasco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChurrascoParticipante_Participante_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoParticipante_ChurrascoId",
                table: "ChurrascoParticipante",
                column: "ChurrascoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoParticipante_ParticipanteId",
                table: "ChurrascoParticipante",
                column: "ParticipanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChurrascoParticipante");

            migrationBuilder.DropTable(
                name: "Churrasco");

            migrationBuilder.DropTable(
                name: "Participante");
        }
    }
}
