using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig12_UpdateUserDb_1003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_USER",
                table: "T_USER");

            migrationBuilder.AddColumn<int>(
                name: "F_ID",
                table: "T_USER",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_USER",
                table: "T_USER",
                column: "F_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_USER",
                table: "T_USER");

            migrationBuilder.DropColumn(
                name: "F_ID",
                table: "T_USER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_USER",
                table: "T_USER",
                column: "F_UserId");
        }
    }
}
