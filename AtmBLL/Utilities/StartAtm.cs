using AtmBLL.Implementation;
using AtmBLL.Interfaces;
using AtmDAL.Database.EFCoreDbSetup;

namespace AtmBLL.Utilities
{
    public class StartAtm
    {
        public static readonly IMessage message = new Message();

        public static async Task Start()
        {
         AtmDbFactory atmDbFactory = new();
            var DbContext = atmDbFactory.CreateDbContext(null);
            
            if (DbContext.Atms != null)
            {
                foreach (var Info in DbContext.Atms)
                {
                    Console.WriteLine($"{Info.Id}. {Info.Name}");
                }
            }

            var AtmData = await GetAtmData.Data();
            if (AtmData != null && AtmData.Id > 0)
            {
                Console.WriteLine($"{AtmData.Name} has booted!");
                Console.WriteLine("Insert Card!");
                return;
            }
            message.Error("Atm does not exist.");
            await Start();
            return;
        }
    }
}
