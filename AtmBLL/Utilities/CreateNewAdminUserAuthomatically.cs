using AtmDAL.Models;
using AtmDAL.Enums;
using AtmDAL.Database.EFCoreDbSetup;

namespace AtmBLL.Utilities
{
    public class CreateNewAdminUserAuthomatically
    {
        public static async Task NewUser()
        {

         AtmDbFactory atmDbFactory = new();
            var DbContext = atmDbFactory.CreateDbContext(null);
        var UserData = new User
            {
                Id = 1,
                FullName = "Kelechi Amos Omeh",
                Email = "kellyncodes@gmail.com",
                Password = "123456",
                PhoneNumber = "2349089024",
                BankId = 2,
                Role = "Admin"
            };
            var AccountData = new Account
            {
                UserId = 1,
                UserName = "KellynCodes",
                AccountNo = "0669976019",
                AccountType = AccountType.Savings,
                Balance = 100_000_000,
                Pin = "12345",
                CreatedDate = DateTime.UtcNow.ToLongDateString()
            };
            
            var SecondUserData = new User
            {
                Id = 2,
                FullName = "Kennedy Chisom Okoye",
                Email = "kelly@gmail.com",
                Password = "654321",
                PhoneNumber = "234090389064",
                BankId = 1,
                Role = "Customer"
            };

           var SecondAccountData = new Account
            {
               UserId = 2,
               UserName = "Kelly",
               AccountNo = "1427103773",
               AccountType = AccountType.Current,
               Balance = 100_000.15m,
               Pin = "54321",
               CreatedDate = DateTime.UtcNow.ToLongDateString()
           };
            await DbContext.Users.AddAsync(UserData);
            await DbContext.Accounts.AddAsync(AccountData);
            await DbContext.Users.AddAsync(SecondUserData);
            await DbContext.Accounts.AddAsync(SecondAccountData);
            string Message = await DbContext.SaveChangesAsync() > 0 ? "Admin defualt user created successfully" : "Admin User was not successful";
            Console.WriteLine(Message);
        }
    }
}
