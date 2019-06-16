using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimchaFund.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CellNumber = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simcha",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SimchaName = table.Column<string>(nullable: true),
                    SimchaDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simcha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deposit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    DepositDate = table.Column<DateTime>(nullable: false),
                    DonorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deposit_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimchaDonor",
                columns: table => new
                {
                    SimchaId = table.Column<int>(nullable: false),
                    DonorId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimchaDonor", x => new { x.DonorId, x.SimchaId });
                    table.ForeignKey(
                        name: "FK_SimchaDonor_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SimchaDonor_Simcha_SimchaId",
                        column: x => x.SimchaId,
                        principalTable: "Simcha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deposit_DonorId",
                table: "deposit",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_SimchaDonor_SimchaId",
                table: "SimchaDonor",
                column: "SimchaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deposit");

            migrationBuilder.DropTable(
                name: "SimchaDonor");

            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "Simcha");
        }
    }
}
