using Domain.Entities;
using FMS_API.Controllers;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace FMS_API.Repositories
{
    public interface IShipmentRepository
    {
        public Task<List<TC_OIM>> getAllOceanImport();
        public Task<TC_OIM> getOceanImportDetail(string rmh_id);
        public Task<List<T_CONTAINER>> getOceanImportContainerList(string id);
    }

    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<TC_OIM>> getAllOceanImport()
        {
            var result = await _context.T_OIMMAIN
                .AsNoTracking()
                .GroupJoin(_context.T_OIHMAIN,
                    x => x.F_ID,
                    y => y.F_OIMMAINID,
                    (x, y) => new { oim = x, oih = y })
                .SelectMany(
                    z => z.oih.DefaultIfEmpty(),
                    (x, y) => new TC_OIM { oim = x.oim, oih = y })
                .ToListAsync() ?? new List<TC_OIM>();

            return result;
        }

        public async Task<TC_OIM> getOceanImportDetail(string rmh_id)
        {
            if (string.IsNullOrEmpty(rmh_id))
                return new TC_OIM();

            var keys_tuple = Utility.getSplitRMHId(rmh_id);
            var refNo = keys_tuple?.Item1 ?? "";
            var masterNo = keys_tuple?.Item2 ?? "";
            var houseNo = keys_tuple?.Item3 ?? "";

            if (string.IsNullOrEmpty(refNo))
                return new TC_OIM();

            var query = _context.T_OIMMAIN.Where(x => x.F_RefNo == refNo).AsQueryable();

            if (!string.IsNullOrEmpty(masterNo))
                query = query.Where(x => x.F_MBLNo == masterNo).AsQueryable();

            var result = await query.AsNoTracking()
                            .GroupJoin(_context.T_OIHMAIN.Where(s => s.F_HBLNo == houseNo),
                                x => x.F_ID,
                                y => y.F_OIMMAINID,
                                (x, y) => new { oim = x, oih = y })
                            .SelectMany(
                                z => z.oih.DefaultIfEmpty(), 
                                (x, y) => new TC_OIM { oim = x.oim, oih = y })
                            .FirstOrDefaultAsync() ?? new TC_OIM();

            return result;
        }

        public async Task<List<T_CONTAINER>> getOceanImportContainerList(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new List<T_CONTAINER>();

            if (!int.TryParse(id, out int fid))
            {
                throw new ArgumentException(
                    String.Format("This value, {0} can not convert to integer", id));
            }

            var result = await _context.T_CONTAINER
                                .Where(x => x.F_TableName == "OIMMAIN" 
                                       && x.F_TableId == fid).ToListAsync();

            return result;
        }
    }
}
