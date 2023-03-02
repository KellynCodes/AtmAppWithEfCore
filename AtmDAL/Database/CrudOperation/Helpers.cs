using AtmDAL.Database.EFCoreDbSetup;

namespace AtmDAL.Database.CrudOperation
{
    public class Helpers
    {
        public static async Task AddChangesAsync(object obj, string message)
        {

            AtmDbFactory amtDbFactory = new();
            var DbContext = amtDbFactory.CreateDbContext(null);

            DbContext.Add(obj);
            int RowsAffected = await DbContext.SaveChangesAsync();
            string Message = RowsAffected > 0 ? message : "Operation was not successfull.";
            Console.WriteLine(Message);
        }
    }
}
