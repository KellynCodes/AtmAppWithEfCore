using System.Threading.Tasks;
using AtmDAL.Database.EFCoreDbSetup;
using AtmDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmBLL.Utilities
{
    public class GetAtmData
    {
        public static Atm GetData { get; private set; }
        public static async Task<Atm> Data()
        {
         AtmDbFactory atmDbFactory = new();
            AtmDbContext DbContext = atmDbFactory.CreateDbContext(null);
        Atm _atm = new Atm();
            var AtmInfo = await DbContext.Atms.FirstOrDefaultAsync(atm => atm.Id == ReturnAtmId.Id());
            if (AtmInfo != null)
            {
                    _atm = AtmInfo;
                    GetData = AtmInfo;
            }
            return _atm;
        }
    }
}
