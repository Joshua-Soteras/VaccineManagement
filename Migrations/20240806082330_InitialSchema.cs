using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csula.labs.HW2.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosesRequired = table.Column<int>(type: "int", nullable: false),
                    DosesInBetween = table.Column<int>(type: "int", nullable: false),
                    DosesRecieved = table.Column<int>(type: "int", nullable: false),
                    TotalDosesLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaccineCompanyId = table.Column<int>(type: "int", nullable: true),
                    FirstDose = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondDose = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Vaccines_VaccineCompanyId",
                        column: x => x.VaccineCompanyId,
                        principalTable: "Vaccines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_VaccineCompanyId",
                table: "Patients",
                column: "VaccineCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Vaccines");
        }
    }
}
