using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig07_ModifyDbStructure_0822 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_CFSLocation",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_FinalDest",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_Operator",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_PaidPlace",
                table: "T_OIHMAIN");

            migrationBuilder.RenameColumn(
                name: "F_CYLocation",
                table: "T_OIMMAIN",
                newName: "F_Carrier");

            migrationBuilder.RenameColumn(
                name: "F_FCode",
                table: "T_OIHMAIN",
                newName: "F_CYLocation");

            migrationBuilder.AddColumn<string>(
                name: "F_CarrierName",
                table: "T_OIMMAIN",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_CarrierName",
                table: "T_OIMMAIN");

            migrationBuilder.RenameColumn(
                name: "F_Carrier",
                table: "T_OIMMAIN",
                newName: "F_CYLocation");

            migrationBuilder.RenameColumn(
                name: "F_CYLocation",
                table: "T_OIHMAIN",
                newName: "F_FCode");

            migrationBuilder.AddColumn<int>(
                name: "F_CFSLocation",
                table: "T_OIMMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_FinalDest",
                table: "T_OIHMAIN",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_Operator",
                table: "T_OIHMAIN",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_PaidPlace",
                table: "T_OIHMAIN",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);
        }
    }
}
