using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMT.API.Migrations
{
    /// <inheritdoc />
    public partial class MyfirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberDetails",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    SkillSet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllocationPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberDetails", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "MemberTaskDetails",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deliverables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTaskDetails", x => x.TaskID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberDetails");

            migrationBuilder.DropTable(
                name: "MemberTaskDetails");
        }
    }
}
