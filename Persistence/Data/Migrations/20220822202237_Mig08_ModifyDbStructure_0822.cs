using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig08_ModifyDbStructure_0822 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CONTAINER",
                columns: table => new
                {
                    F_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_TableName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    F_TableId = table.Column<int>(type: "int", nullable: true),
                    F_BLNO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    F_ContainerNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    F_ConType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    F_SealNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_BookingNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    F_BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_LastFreeDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_PickupNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    F_PickupPlace = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    F_Carrier = table.Column<int>(type: "int", nullable: true),
                    F_CreatedUser = table.Column<int>(type: "int", nullable: true),
                    F_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_Commodity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    F_HSCODE = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    F_PKGS = table.Column<int>(type: "int", nullable: true),
                    F_KGSLBS = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    F_LoadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_ATD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_ATA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_UnloadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_Memo = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CONTAINER", x => x.F_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CONTAINER");
        }
    }
}
