using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig01_BasicStructure_OimmainOihmain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_OIHMAIN",
                columns: table => new
                {
                    F_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_OIMMAINID = table.Column<int>(type: "int", nullable: false),
                    F_HBLNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    F_Customer = table.Column<int>(type: "int", nullable: false),
                    F_Shipper = table.Column<int>(type: "int", nullable: false),
                    F_SName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    F_Consignee = table.Column<int>(type: "int", nullable: false),
                    F_CName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    F_Notify = table.Column<int>(type: "int", nullable: false),
                    F_NName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    F_Broker = table.Column<int>(type: "int", nullable: false),
                    F_BName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    F_Commodity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    F_CustRefNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    F_Pkgs = table.Column<float>(type: "real", nullable: false),
                    F_Punit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    F_CBM = table.Column<float>(type: "real", nullable: false),
                    F_KGS = table.Column<float>(type: "real", nullable: false),
                    F_LBS = table.Column<float>(type: "real", nullable: false),
                    F_ExpRLS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_CFSLocation = table.Column<int>(type: "int", nullable: false),
                    F_FCode = table.Column<int>(type: "int", nullable: false),
                    F_FinalDest = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    F_FETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_ITClass = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    F_PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_ITCarrier = table.Column<int>(type: "int", nullable: false),
                    F_ITNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    F_ITPlace = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    F_ITDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_DCodeCustom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    F_FCodeCustom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    F_ForeignDest = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    F_PPCC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    F_SManID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    F_Mark = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    F_MarkPkg = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    F_Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    F_MarkGross = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    F_MarkMeasure = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    F_FileClosed = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_ClosedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    F_Operator = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    F_SelectContainer = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_MoveType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    F_Nomi = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_IMemo = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    F_PMemo = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    F_DefaultRate = table.Column<float>(type: "real", nullable: false),
                    F_INVOICETO = table.Column<int>(type: "int", nullable: false),
                    F_DoorMove = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_AMSBLNO = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    F_ISFNO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OIHMAIN", x => x.F_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_OIMMAIN",
                columns: table => new
                {
                    F_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_MBLNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    F_RefNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    F_AgentRefNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    F_SMBLNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    F_mCommodity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    F_Agent = table.Column<int>(type: "int", nullable: false),
                    F_ETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_ETD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_Vessel = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    F_Voyage = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    F_SteamShip = table.Column<int>(type: "int", nullable: false),
                    F_LCode = table.Column<int>(type: "int", nullable: false),
                    F_LoadingPort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    F_DCode = table.Column<int>(type: "int", nullable: false),
                    F_DisCharge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    F_CYLocation = table.Column<int>(type: "int", nullable: false),
                    F_CFSLocation = table.Column<int>(type: "int", nullable: false),
                    F_PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_LCLFCL = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_ITCarrier = table.Column<int>(type: "int", nullable: false),
                    F_ITNo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    F_ITPlace = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    F_ITClass = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    F_ITDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_FCode = table.Column<int>(type: "int", nullable: false),
                    F_FinalDest = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    F_FETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    F_PPCC = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    F_SVCCNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    F_FeederVessel = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    F_MoveType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    F_ExpRLS = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_FileClosed = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    F_ClosedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OIMMAIN", x => x.F_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_OIHMAIN");

            migrationBuilder.DropTable(
                name: "T_OIMMAIN");
        }
    }
}
