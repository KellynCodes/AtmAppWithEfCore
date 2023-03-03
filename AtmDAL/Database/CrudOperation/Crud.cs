using AtmDAL.Database.EFCoreDbSetup;
using AtmDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmDAL.Database.CrudOperation
{
    public class Crud
    {
        private readonly AtmDbFactory atmDbFactory = new();
        public static async Task InsertIntoTransactionTableAsync(int sender, int reciever, decimal transactionAmount, string transactionType, string transactionDate)
        {
            var NewTransaction = new Transaction
            {
                SenderId = sender,
                ReceiverId = reciever,
                TransactionAmount = transactionAmount,
                TransactionType = transactionType,
                TransactionDate = transactionDate,
                CreatedDate  = transactionDate
            };

            string Message = "Transaction stored succesfully";
            await Helpers.AddChangesAsync(NewTransaction, Message);
        }

        public async Task MinusFromAccountAmountAsync(int userId, decimal amount)
        {
            AtmDbContext DbContext = atmDbFactory.CreateDbContext(null);
           var UserAccount = await DbContext.Accounts.SingleOrDefaultAsync(account => account.UserId == userId);
            if(UserAccount != null)
            {
                UserAccount.Balance -= amount;
            }
            await DbContext.SaveChangesAsync();
            Console.WriteLine("Your balance has been update successfully.");
        }
        public async Task AddToAccountAmountAsync(int userId, decimal amount)
        {
            AtmDbContext DbContext = atmDbFactory.CreateDbContext(null);
           var UserAccount = await DbContext.Accounts.SingleOrDefaultAsync(account => account.UserId == userId);
            if(UserAccount != null)
            {
                UserAccount.Balance -= amount;
            }
            await DbContext.SaveChangesAsync();
            Console.WriteLine("Your balance has been update successfully.");
        }
        
        public async Task UpdateAccountPinAsync(int userId, string pin)
        {
            AtmDbContext DbContext = atmDbFactory.CreateDbContext(null);
           var UserAccount = await DbContext.Accounts.SingleOrDefaultAsync(account => account.UserId == userId);
            if(UserAccount != null)
            {
                UserAccount.Pin = pin;
            }
            await DbContext.SaveChangesAsync();
            Console.WriteLine("Your balance has been update successfully.");
        }


        public async Task MinusFromAtmAmountAsync(int atmId, decimal atmAvailableCash)
        {
            AtmDbContext DbContext = atmDbFactory.CreateDbContext(null);
            var AtmInfo = await DbContext.Atms.SingleOrDefaultAsync(atm => atm.Id == atmId);
            if (AtmInfo != null)
            {
                AtmInfo.AvailableCash -= atmAvailableCash;
            }
            await DbContext.SaveChangesAsync();
            Console.WriteLine("Your balance has been update successfully.");
        }

        public async Task AddToAtmAmountAsync(int atmId, decimal atmAvailableCash)
        {
            AtmDbContext DbContext = atmDbFactory.CreateDbContext(null);
            var AtmInfo = await DbContext.Atms.SingleOrDefaultAsync(atm => atm.Id == atmId);
            if (AtmInfo != null)
            {
                AtmInfo.AvailableCash += atmAvailableCash;
            }
            await DbContext.SaveChangesAsync();
            Console.WriteLine("Your balance has been update successfully.");
        }
    }
}
