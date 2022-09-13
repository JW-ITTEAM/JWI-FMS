using Persistence.Data.SeedData;

namespace Persistence.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.RemoveRange(_context.T_OIMMAIN);
            _context.RemoveRange(_context.T_OIHMAIN);
            _context.SaveChanges();

            var oimmainobj = new SeedOimmainList();
            var oimmain_list = oimmainobj.get_OIMMAIN_Seed();
            _context.T_OIMMAIN.AddRange(oimmain_list);

            var oihmainobj = new SeedOihmainList();
            var oihmain_list = oihmainobj.get_OIHMAIN_Seed();
            _context.T_OIHMAIN.AddRange(oihmain_list);

            _context.SaveChanges();
        }

    }
}
