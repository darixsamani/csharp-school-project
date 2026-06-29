using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleEmployeesManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEmployeeEthnicity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ethnicity",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ethnicity",
                table: "Employees");
        }
    }
}
