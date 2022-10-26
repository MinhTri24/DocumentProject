using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DocumentProject.Data.Migrations
{
    public partial class UpdateDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Documents",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Documents",
                newName: "CreateAt");
        }
    }
}
