using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<T_USER>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Lazy loading set off
            ChangeTracker.LazyLoadingEnabled = false;

            // Last Update Version
            // Database Document 08222022
        }        
        public DbSet<T_OIMMAIN> T_OIMMAIN { get; set; }
        public DbSet<T_OIHMAIN> T_OIHMAIN { get; set; }
        public DbSet<T_USER> T_USER { get; set; }
        public DbSet<T_FILEMAIN> T_FILEMAIN { get; set; }
        public DbSet<T_COMPANY> T_COMPANY { get; set; }
        public DbSet<T_CONTAINER> T_CONTAINER { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUser>().ToTable("T_USER");            
            //modelBuilder.Entity<IdentityRole>().ToTable("T_ROLE");
            //modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("T_USERCLAIM");
            //modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("T_ROLECLAIM");
            //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("T_USERLOGIN");
            //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("T_USERTOKEN");

            modelBuilder.Entity<T_CONTAINER>(opt =>
            {
                opt.HasKey(x => x.F_ID);
                opt.Property(x => x.F_TableName).HasMaxLength(10);
                //opt.Property(x => x.F_BLNO).HasMaxLength(15);
                opt.Property(x => x.F_ContainerNo).HasMaxLength(11);
                opt.Property(x => x.F_ConType).HasMaxLength(10);
                opt.Property(x => x.F_SealNo).HasMaxLength(20);
                opt.Property(x => x.F_BookingNo).HasMaxLength(15);
                opt.Property(x => x.F_PickupNo).HasMaxLength(15);
                opt.Property(x => x.F_PickupPlace).HasMaxLength(60);
                opt.Property(x => x.F_Commodity).HasMaxLength(100);
                opt.Property(x => x.F_HSCODE).HasMaxLength(30);
                opt.Property(x => x.F_KGSLBS).HasMaxLength(30);
                opt.Property(x => x.F_Memo).HasMaxLength(800);
            });

            modelBuilder.Entity<T_USER>(opt =>
            {
                opt.HasKey(x => x.F_UserId);
                opt.Property(x => x.F_UserId).HasMaxLength(20);
                opt.Property(x => x.F_UserPwd).HasMaxLength(20);
                opt.Property(x => x.F_UserName).HasMaxLength(30);
                opt.Property(x => x.F_UserEmail).HasMaxLength(100);
                opt.Property(x => x.F_Phone).HasMaxLength(20);
                opt.Property(x => x.F_FAX).HasMaxLength(20);
                opt.Property(x => x.F_Dept).HasMaxLength(10);                
            });

            modelBuilder.Entity<T_COMPANY>(opt =>
            {
                opt.HasKey(x => x.F_ID);
                opt.Property(x => x.F_SName).HasMaxLength(50);
                opt.Property(x => x.F_FName).HasMaxLength(50);
                opt.Property(x => x.F_Group).HasMaxLength(10);
                opt.Property(x => x.F_Addr).HasMaxLength(200);
                opt.Property(x => x.F_City).HasMaxLength(20);
                opt.Property(x => x.F_State).HasMaxLength(2);
                opt.Property(x => x.F_ZipCode).HasMaxLength(10);
                opt.Property(x => x.F_Country).HasMaxLength(50);
                opt.Property(x => x.F_Phone).HasMaxLength(20);
                opt.Property(x => x.F_FAX).HasMaxLength(20);
                opt.Property(x => x.F_EMAIL).HasMaxLength(50);
                opt.Property(x => x.F_Website).HasMaxLength(50);
                opt.Property(x => x.F_Credential).HasMaxLength(50);
                opt.Property(x => x.F_AccountNo).HasMaxLength(50);
                opt.Property(x => x.F_IRSNo).HasMaxLength(20);
                opt.Property(x => x.F_IRSType).HasMaxLength(1);
                opt.Property(x => x.F_BondNo).HasMaxLength(50);
                opt.Property(x => x.F_IATANo).HasMaxLength(50);
                opt.Property(x => x.F_PIMSTYPE).HasMaxLength(10);
                opt.Property(x => x.F_PIMSCNTRY).HasMaxLength(2);
            });

            modelBuilder.Entity<T_FILEMAIN>(opt =>
            {
                opt.HasKey(x => x.F_ID);
                opt.Property(x => x.F_TableName).HasMaxLength(20);
                opt.Property(x => x.F_BLNO).HasMaxLength(20);
                opt.Property(x => x.F_FILENAME).HasMaxLength(100);
                opt.Property(x => x.F_FILEPATH).HasMaxLength(100);
                opt.Property(x => x.F_APIKEY).HasMaxLength(100);
                opt.Property(x => x.F_UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<T_OIMMAIN>(opt =>
            {
                opt.HasKey(x => x.F_ID);
                opt.Property(x => x.F_MBLNo).HasMaxLength(20);
                opt.Property(x => x.F_RefNo).HasMaxLength(20);
                opt.Property(x => x.F_AgentRefNo).HasMaxLength(30);
                opt.Property(x => x.F_SMBLNo).HasMaxLength(20);
                opt.Property(x => x.F_mCommodity).HasMaxLength(100);
                opt.Property(x => x.F_SName).HasMaxLength(250);
                opt.Property(x => x.F_CName).HasMaxLength(250);
                opt.Property(x => x.F_NName).HasMaxLength(250);
                opt.Property(x => x.F_BName).HasMaxLength(100);
                opt.Property(x => x.F_Agent).HasMaxLength(100);
                opt.Property(x => x.F_Vessel).HasMaxLength(25);
                opt.Property(x => x.F_Voyage).HasMaxLength(15);
                opt.Property(x => x.F_CarrierName).HasMaxLength(25);
                opt.Property(x => x.F_LoadingPort).HasMaxLength(50);
                opt.Property(x => x.F_DisCharge).HasMaxLength(50);
                opt.Property(x => x.F_LCLFCL).HasMaxLength(1);
                opt.Property(x => x.F_ITNo).HasMaxLength(12);
                opt.Property(x => x.F_ITPlace).HasMaxLength(20);
                //opt.Property(x => x.F_ITClass).HasMaxLength(5);
                opt.Property(x => x.F_FinalDelivery).HasMaxLength(50);
                opt.Property(x => x.F_FinalDest).HasMaxLength(25);
                opt.Property(x => x.F_PPCC).HasMaxLength(2);
                opt.Property(x => x.F_PaidPlace).HasMaxLength(30);
                opt.Property(x => x.F_SVCCNo).HasMaxLength(30);
                opt.Property(x => x.F_FeederVessel).HasMaxLength(25);
                opt.Property(x => x.F_MoveType).HasMaxLength(25);
                opt.Property(x => x.F_ExpRLS).HasMaxLength(1);
                opt.Property(x => x.F_FileClosed).HasMaxLength(1);
                opt.Property(x => x.F_ClosedBy).HasMaxLength(10);
                opt.Property(x => x.F_Memo).HasMaxLength(2000);
            });

            modelBuilder.Entity<T_OIHMAIN>(opt =>
            {
                opt.HasKey(x => x.F_ID);
                opt.Property(x => x.F_HBLNo).HasMaxLength(20);
                opt.Property(x => x.F_SName).HasMaxLength(250);
                opt.Property(x => x.F_CName).HasMaxLength(250);
                opt.Property(x => x.F_NName).HasMaxLength(250);
                opt.Property(x => x.F_BName).HasMaxLength(100);
                opt.Property(x => x.F_CustRefNo).HasMaxLength(50);
                //opt.Property(x => x.F_Punit).HasMaxLength(10);
                opt.Property(x => x.F_Commodity).HasMaxLength(100);
                opt.Property(x => x.F_HSCODE).HasMaxLength(25);
                opt.Property(x => x.F_MarkPkg).HasMaxLength(800);
                opt.Property(x => x.F_Description).HasMaxLength(800);
                opt.Property(x => x.F_MarkGross).HasMaxLength(800);
                opt.Property(x => x.F_MarkMeasure).HasMaxLength(800);
                opt.Property(x => x.F_ExpRLS).HasMaxLength(1);
                //opt.Property(x => x.F_FinalDest).HasMaxLength(25);
                //opt.Property(x => x.F_ITClass).HasMaxLength(5);
                //opt.Property(x => x.F_ITNo).HasMaxLength(20);
                //opt.Property(x => x.F_ITPlace).HasMaxLength(20);
                opt.Property(x => x.F_DcodeCustom).HasMaxLength(5);
                opt.Property(x => x.F_FcodeCustom).HasMaxLength(5);
                opt.Property(x => x.F_ForeignDest).HasMaxLength(25);
                opt.Property(x => x.F_PPCC).HasMaxLength(2);
                //opt.Property(x => x.F_PaidPlace).HasMaxLength(2);
                //opt.Property(x => x.F_SManID).HasMaxLength(10);
                opt.Property(x => x.F_Mark).HasMaxLength(800);                
                opt.Property(x => x.F_FileClosed).HasMaxLength(1);
                opt.Property(x => x.F_ClosedBy).HasMaxLength(10);
                //opt.Property(x => x.F_Operator).HasMaxLength(10);
                //opt.Property(x => x.F_SelectContainer).HasMaxLength(1);
                opt.Property(x => x.F_MoveType).HasMaxLength(15);
                opt.Property(x => x.F_Nomi).HasMaxLength(1);                
                //opt.Property(x => x.F_IMemo).HasMaxLength(800);
                //opt.Property(x => x.F_PMemo).HasMaxLength(800);
                //opt.Property(x => x.F_DoorMove).HasMaxLength(1);
                opt.Property(x => x.F_AMSBLNO).HasMaxLength(16);
                opt.Property(x => x.F_ISFNO).HasMaxLength(20);
                opt.Property(x => x.F_Memo).HasMaxLength(2000);
            });
        }
        
    }
}
