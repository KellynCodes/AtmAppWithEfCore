using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AtmDAL.Database.EFCoreDbSetup
{
    public class AtmDbFactory : IDesignTimeDbContextFactory<AtmDbContext>
    {
        public AtmDbContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<AtmDbContext>();
            var ConnectionString = @"Data Source=DESKTOP-N2LHC09;Initial Catalog=AtmEfCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            OptionBuilder.UseSqlServer(ConnectionString);
            return new AtmDbContext(OptionBuilder.Options);
        }
    }
}
