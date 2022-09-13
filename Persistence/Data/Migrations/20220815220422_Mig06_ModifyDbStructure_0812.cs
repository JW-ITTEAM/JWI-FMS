using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class Mig06_ModifyDbStructure_0812 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_ITCarrier",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_ITClass",
                table: "T_OIMMAIN");

            migrationBuilder.DropColumn(
                name: "F_ITCarrier",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_ITClass",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_ITDate",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_ITNo",
                table: "T_OIHMAIN");

            migrationBuilder.DropColumn(
                name: "F_ITPlace",
                table: "T_OIHMAIN");

            migrationBuilder.AddColumn<string>(
                name: "F_PaidPlace",
                table: "T_OIHMAIN",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T_COMPANY",
                columns: table => new
                {
                    F_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_SName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_Group = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    F_STATUS = table.Column<int>(type: "int", nullable: true),
                    F_Addr = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    F_City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    F_ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    F_Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_FAX = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_Website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_Credential = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_AccountNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_CreditLimit = table.Column<float>(type: "real", nullable: true),
                    F_Terms = table.Column<int>(type: "int", nullable: true),
                    F_IRSNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_IRSType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    F_BondNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_IATANo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_PIMSID = table.Column<int>(type: "int", nullable: true),
                    F_PIMSTYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    F_PIMSRPARTY = table.Column<int>(type: "int", nullable: true),
                    F_PIMSCNTRY = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    F_AccountingContact = table.Column<int>(type: "int", nullable: true),
                    F_DeliveryContact = table.Column<int>(type: "int", nullable: true),
                    F_OfficeContact = table.Column<int>(type: "int", nullable: true),
                    F_PickUpContact = table.Column<int>(type: "int", nullable: true),
                    F_CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_CreateBy = table.Column<int>(type: "int", nullable: true),
                    F_UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_UpdateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_COMPANY", x => x.F_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_FILEMAIN",
                columns: table => new
                {
                    F_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_FILETYPE = table.Column<int>(type: "int", nullable: true),
                    F_TableName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_TableId = table.Column<int>(type: "int", nullable: true),
                    F_RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_BLNO = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_FILENAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    F_FILEPATH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    F_FILESTATUS = table.Column<int>(type: "int", nullable: true),
                    F_APIKEY = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    F_JSON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    F_UserId = table.Column<int>(type: "int", nullable: true),
                    F_UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    F_CompanyId = table.Column<int>(type: "int", nullable: true),
                    F_UploadTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_FILEMAIN", x => x.F_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_USER",
                columns: table => new
                {
                    F_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_UserId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_UserPwd = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    F_UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    F_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_FAX = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    F_Level = table.Column<int>(type: "int", nullable: true),
                    F_Dept = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    F_CompanyId = table.Column<int>(type: "int", nullable: true),
                    F_Status = table.Column<int>(type: "int", nullable: true),
                    F_LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_CreateBy = table.Column<int>(type: "int", nullable: true),
                    F_UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    F_UpdateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.F_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_COMPANY");

            migrationBuilder.DropTable(
                name: "T_FILEMAIN");

            migrationBuilder.DropTable(
                name: "T_USER");

            migrationBuilder.DropColumn(
                name: "F_PaidPlace",
                table: "T_OIHMAIN");

            migrationBuilder.AddColumn<int>(
                name: "F_ITCarrier",
                table: "T_OIMMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_ITClass",
                table: "T_OIMMAIN",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "F_ITCarrier",
                table: "T_OIHMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_ITClass",
                table: "T_OIHMAIN",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "F_ITDate",
                table: "T_OIHMAIN",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_ITNo",
                table: "T_OIHMAIN",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "F_ITPlace",
                table: "T_OIHMAIN",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
