using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig03_ModifySomeTypes_Oihmain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "F_Pkgs",
                table: "T_OIHMAIN",
                newName: "F_PKGS");

            migrationBuilder.AlterColumn<string>(
                name: "F_ITPlace",
                table: "T_OIHMAIN",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "F_PKGS",
                table: "T_OIHMAIN",
                newName: "F_Pkgs");

            migrationBuilder.AlterColumn<int>(
                name: "F_ITPlace",
                table: "T_OIHMAIN",
                type: "int",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
