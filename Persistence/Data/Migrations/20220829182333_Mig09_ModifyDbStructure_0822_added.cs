using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig09_ModifyDbStructure_0822_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_BLNO",
                table: "T_CONTAINER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "F_BLNO",
                table: "T_CONTAINER",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }
    }
}
