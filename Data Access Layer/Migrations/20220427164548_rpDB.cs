using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Layer.Migrations
{
    public partial class rpDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPanNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UserBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approver = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Reimbursement",
                columns: table => new
                {
                    ReimbursementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReimbursementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedValue = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestPhase = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Receipt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reimbursement", x => x.ReimbursementId);
                    table.ForeignKey(
                        name: "FK_Reimbursement_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminDashboardEntity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedValue = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReimbursementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDashboardEntity", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AdminDashboardEntity_Reimbursement_ReimbursementId",
                        column: x => x.ReimbursementId,
                        principalTable: "Reimbursement",
                        principalColumn: "ReimbursementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminDashboardEntity_ReimbursementId",
                table: "AdminDashboardEntity",
                column: "ReimbursementId");

            migrationBuilder.CreateIndex(
                name: "IX_Reimbursement_UserId",
                table: "Reimbursement",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDashboardEntity");

            migrationBuilder.DropTable(
                name: "Reimbursement");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
