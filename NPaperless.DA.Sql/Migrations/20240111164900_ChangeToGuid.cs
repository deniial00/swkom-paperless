using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NPaperless.DA.Sql.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Documents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Documents");
        }
    }
}
