using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig04_ModifyDbStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_CBM",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_DoorMove",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_IMemo",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_KGS",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_LBS",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_PKGS",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_Punit",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_SManID",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_SelectContainer",
                table: "T_OIHMAIN");

            migrationBuilder.RenameColumn(
                name: "F_SteamShip",
                table: "T_OIMMAIN",
                newName: "F_TotalContainer");

            migrationBuilder.RenameColumn(
                name: "F_FCodeCustom",
                table: "T_OIHMAIN",
                newName: "F_FcodeCustom");

            migrationBuilder.RenameColumn(
                name: "F_DCodeCustom",
                table: "T_OIHMAIN",
                newName: "F_DcodeCustom");

            migrationBuilder.RenameColumn(
                name: "F_PMemo",
                table: "T_OIHMAIN",
                newName: "F_Memo");

            migrationBuilder.AddColumn<string>(
                name: "F_AgentName",
                table: "T_OIMMAIN",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_BName",
                table: "T_OIMMAIN",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_Broker",
                table: "T_OIMMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_CName",
                table: "T_OIMMAIN",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_Consignee",
                table: "T_OIMMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_FinalDelivery",
                table: "T_OIMMAIN",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_NName",
                table: "T_OIMMAIN",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_Notify",
                table: "T_OIMMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_PaidPlace",
                table: "T_OIMMAIN",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_SName",
                table: "T_OIMMAIN",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_Shipper",
                table: "T_OIMMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_HSCODE",
                table: "T_OIHMAIN",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_TotalContainer",
                table: "T_OIHMAIN",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_AgentName",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_BName",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_Broker",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_CName",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_Consignee",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_FinalDelivery",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_NName",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_Notify",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_PaidPlace",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_SName",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_Shipper",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_HSCODE",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_TotalContainer",
                table: "T_OIHMAIN");

            migrationBuilder.RenameColumn(
                name: "F_TotalContainer",
                table: "T_OIMMAIN",
                newName: "F_SteamShip");

            migrationBuilder.RenameColumn(
                name: "F_FcodeCustom",
                table: "T_OIHMAIN",
                newName: "F_FCodeCustom");

            migrationBuilder.RenameColumn(
                name: "F_DcodeCustom",
                table: "T_OIHMAIN",
                newName: "F_DCodeCustom");

            migrationBuilder.RenameColumn(
                name: "F_Memo",
                table: "T_OIHMAIN",
                newName: "F_PMemo");

            migrationBuilder.AddColumn<float>(
                name: "F_CBM",
                table: "T_OIHMAIN",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_DoorMove",
                table: "T_OIHMAIN",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_IMemo",
                table: "T_OIHMAIN",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "F_KGS",
                table: "T_OIHMAIN",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "F_LBS",
                table: "T_OIHMAIN",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "F_PKGS",
                table: "T_OIHMAIN",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_Punit",
                table: "T_OIHMAIN",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_SManID",
                table: "T_OIHMAIN",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_SelectContainer",
                table: "T_OIHMAIN",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);
        }
    }
}
