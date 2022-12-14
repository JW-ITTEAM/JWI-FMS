// <auto-generated />
using System;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220803220130_Mig03_ModifySomeTypes_Oihmain")]
    partial class Mig03_ModifySomeTypes_Oihmain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Persistence.Models.SuperHero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SuperHeroes");
                });

            modelBuilder.Entity("Persistence.Models.T_OIHMAIN", b =>
                {
                    b.Property<int>("F_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("F_ID"), 1L, 1);

                    b.Property<string>("F_AMSBLNO")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("F_BName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("F_Broker")
                        .HasColumnType("int");

                    b.Property<float?>("F_CBM")
                        .HasColumnType("real");

                    b.Property<int?>("F_CFSLocation")
                        .HasColumnType("int");

                    b.Property<string>("F_CName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("F_ClosedBy")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("F_Commodity")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("F_Consignee")
                        .HasColumnType("int");

                    b.Property<string>("F_CustRefNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("F_Customer")
                        .HasColumnType("int");

                    b.Property<string>("F_DCodeCustom")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<float?>("F_DefaultRate")
                        .HasColumnType("real");

                    b.Property<string>("F_Description")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("F_DoorMove")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("F_ExpRLS")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("F_FCode")
                        .HasColumnType("int");

                    b.Property<string>("F_FCodeCustom")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("F_FETA")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_FileClosed")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("F_FinalDest")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("F_ForeignDest")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("F_HBLNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("F_IMemo")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int?>("F_INVOICETO")
                        .HasColumnType("int");

                    b.Property<string>("F_ISFNO")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("F_ITCarrier")
                        .HasColumnType("int");

                    b.Property<string>("F_ITClass")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("F_ITDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_ITNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("F_ITPlace")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float?>("F_KGS")
                        .HasColumnType("real");

                    b.Property<float?>("F_LBS")
                        .HasColumnType("real");

                    b.Property<string>("F_Mark")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("F_MarkGross")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("F_MarkMeasure")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("F_MarkPkg")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("F_MoveType")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("F_NName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("F_Nomi")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("F_Notify")
                        .HasColumnType("int");

                    b.Property<int?>("F_OIMMAINID")
                        .HasColumnType("int");

                    b.Property<string>("F_Operator")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<float?>("F_PKGS")
                        .HasColumnType("real");

                    b.Property<string>("F_PMemo")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<string>("F_PPCC")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime?>("F_PickupDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_Punit")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("F_SManID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("F_SName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("F_SelectContainer")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("F_Shipper")
                        .HasColumnType("int");

                    b.HasKey("F_ID");

                    b.ToTable("T_OIHMAIN");
                });

            modelBuilder.Entity("Persistence.Models.T_OIMMAIN", b =>
                {
                    b.Property<int>("F_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("F_ID"), 1L, 1);

                    b.Property<int?>("F_Agent")
                        .HasColumnType("int");

                    b.Property<string>("F_AgentRefNo")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("F_CFSLocation")
                        .HasColumnType("int");

                    b.Property<int?>("F_CYLocation")
                        .HasColumnType("int");

                    b.Property<string>("F_ClosedBy")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("F_DCode")
                        .HasColumnType("int");

                    b.Property<string>("F_DisCharge")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("F_ETA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("F_ETD")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_ExpRLS")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("F_FCode")
                        .HasColumnType("int");

                    b.Property<DateTime?>("F_FETA")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_FeederVessel")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("F_FileClosed")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("F_FinalDest")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("F_ITCarrier")
                        .HasColumnType("int");

                    b.Property<string>("F_ITClass")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("F_ITDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_ITNo")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("F_ITPlace")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("F_LCLFCL")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("F_LCode")
                        .HasColumnType("int");

                    b.Property<string>("F_LoadingPort")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("F_MBLNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("F_MoveType")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("F_PPCC")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime?>("F_PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("F_RefNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("F_SMBLNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("F_SVCCNo")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("F_SteamShip")
                        .HasColumnType("int");

                    b.Property<string>("F_Vessel")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("F_Voyage")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("F_mCommodity")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("F_ID");

                    b.ToTable("T_OIMMAIN");
                });
#pragma warning restore 612, 618
        }
    }
}
