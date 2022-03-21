using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "engineers",
                columns: table => new
                {
                    EngineerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EngineerName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engineers", x => x.EngineerId);
                });

            migrationBuilder.CreateTable(
                name: "machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MachineName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machines", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "repair_licenses",
                columns: table => new
                {
                    RepairLicenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EngineerId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repair_licenses", x => x.RepairLicenseId);
                    table.ForeignKey(
                        name: "FK_repair_licenses_engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "engineers",
                        principalColumn: "EngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_repair_licenses_machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_repair_licenses_EngineerId",
                table: "repair_licenses",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_repair_licenses_MachineId",
                table: "repair_licenses",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "repair_licenses");

            migrationBuilder.DropTable(
                name: "engineers");

            migrationBuilder.DropTable(
                name: "machines");
        }
    }
}
