using AtmDAL.Models;
using AtmDAL.Enums;
using AtmDAL.Database.EFCoreDbSetup;
using AtmBLL.Interfaces;
using AtmBLL.Implementation;

namespace AtmBLL.Utilities
{
    public class CreateNewAdminUserAuthomatically
    {
        public static async Task NewUser()
        {

        IMessage message = new Message();
         AtmDbFactory atmDbFactory = new();
            var DbContext = atmDbFactory.CreateDbContext(null);
        var UserData = new User
            {
                FullName = "Kelechi Amos Omeh",
                Email = "kellyncode@gmail.com",
                Password = "123456",
                PhoneNumber = "2340089024",
                BankId = 2,
                Role = "Admin",
               CreatedDate = DateTime.UtcNow.ToLongDateString()

        };
            var AccountData = new Account
            {
                UserId = 5,
                UserName = "KellynCodes",
                AccountNo = "0669976019",
                AccountType = AccountType.Savings,
                Balance = 100_000_000,
                Pin = "1234",
                CreatedDate = DateTime.UtcNow.ToLongDateString()
            };
            
            var SecondUserData = new User
            {
                FullName = "Kennedy Chisom Okoye",
                Email = "kellys@gmail.com",
                Password = "654321",
                PhoneNumber = "234690389064",
                BankId = 1,
                Role = "Customer",
               CreatedDate = DateTime.UtcNow.ToLongDateString()

            };

           var SecondAccountData = new Account
            {
               UserId = 4,
               UserName = "Kelly",
               AccountNo = "1427103773",
               AccountType = AccountType.Current,
               Balance = 100_000.15m,
               Pin = "5432",
               CreatedDate = DateTime.UtcNow.ToLongDateString()
           };
            try
            {
                await DbContext.Users.AddAsync(UserData);
                await DbContext.Accounts.AddAsync(AccountData);
                await DbContext.Users.AddAsync(SecondUserData);
                await DbContext.AddAsync(SecondAccountData);
            }catch(Exception ex)
            {
                message.Error(ex.Message);
               await MainMethod.GetUserChoice();
            }
        }
    }
}
