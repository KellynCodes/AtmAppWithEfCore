using AtmBLL.Interfaces;
using AtmBLL.Utilities;
using AtmDAL.Models;
using AtmDAL.Enums;
using Microsoft.EntityFrameworkCore;
using AtmDAL.Database.EFCoreDbSetup;
using AtmDAL.Database.CrudOperation;

namespace AtmBLL.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IMessage message = new Message();
        private readonly IContinueOrEndProcess continueOrEndProcess = new ContinueOrEndProcess();
        private readonly AtmDbFactory atmDbFactory = new();
        private readonly Crud crud = new();

       

        private User SessionAdmin { get; set; }
        public decimal CashLimit { get; set; }

        public async Task LoginAdmin()
        {
            var DbContext = atmDbFactory.CreateDbContext(null);
        Start: Console.WriteLine("Enter your Email");
            string UserEmail = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(UserEmail))
            {
                message.Error("Input was empty of not valid. Please try agian");
                goto Start;
            }  
        Password: Console.WriteLine("Enter your Password");
            string UserPassword = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(UserPassword))
            {
                message.Error("Input was empty of not valid. Please try agian");
                goto Password;
            }

            var UserDetails = await DbContext.Users.FirstOrDefaultAsync(user => user.Email == UserEmail && user.Password == UserPassword);
            if (UserDetails != null)
            {
            SessionAdmin = UserDetails;
                message.Alert($"Welcome back {UserDetails.FullName}");
            AtmServices: Console.WriteLine("What would like to Do");    
                Console.WriteLine("1.\t Create Database\n2.\t Reload Cash\n3.\t Set Cash Limit\n4.\t View list of Users");
                string userInput = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    message.Error("Input was empty or not valid");
                    goto AtmServices;
                }
                if (int.TryParse(userInput, out int answer))
                {
                    switch (answer)
                    {
                            case (int)SwitchCase.One:
                          await ReloadCash();
                            break;
                        case (int)SwitchCase.Two:
                           await SetCashLimit();
                            break;
                        case (int)SwitchCase.Three:
                        await ViewListOfUsers();
                            break;
                        default:
                            message.Error("Entered value was not in the list");
                            goto AtmServices;
                    }
                }
            }
            else
            {
                message.Error("Opps!. Sorry this users does not exist. Please try again with a valid user information");
                goto Start;
            }
        }


        public async Task SetCashLimit()
        {
            EnterCashLimit: message.AlertInfo($"Hi {SessionAdmin.FullName} How much do you want to set as cash limit?.");
            if (decimal.TryParse(Console.ReadLine(), out decimal cashLimit))
            {
                CashLimit = cashLimit;
                message.Success($"{SessionAdmin.FullName} Cash limit set successfully.");
            }
            else
            {
                message.Error("Wrong input. Please enter only numbers.");
                goto EnterCashLimit;
            }
            await continueOrEndProcess.Answer();
        }

        public async Task ReloadCash()
        {
            var DbContext = atmDbFactory.CreateDbContext(null);
        EnterAmount: Console.WriteLine("Enter amount to reload");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                var AtmInfo = await DbContext.Atms.FirstOrDefaultAsync(atm => atm.Id == ReturnAtmId.Id());
              if(AtmInfo != null)
                {
                    message.Success($"Reloading {amount}...");
                    decimal UpdatedAmount = AtmInfo.AvailableCash += amount;
                    await crud.UpdateAtmAmountAsync(ReturnAtmId.Id(), UpdatedAmount);
                    message.Alert($"New Balance :: {AtmInfo.AvailableCash}");
                    await MainMethod.GetUserChoice();
                }
            }
            else
            {
                message.Error("Input was not valid. Please Try again.");
                goto EnterAmount;
            }
        }

        public async Task ViewListOfUsers()
        {
            var DbContext = atmDbFactory.CreateDbContext(null);
            var Users = DbContext.Users;
            message.Alert("\n These are the List of your users.");
            foreach (var user in Users)
            {
                Console.WriteLine($"| {user.Id} | {user.FullName}");
            }
           await MainMethod.Logout();
        }
        
        public async Task ViewListOfTransactions()
        {
            var DbContext = atmDbFactory.CreateDbContext(null);
            var Transactions = DbContext.Transactions;
            message.Alert("\n These are the List of your users.");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine($"| {transaction.Id} | {transaction.SenderId} | {transaction.ReceiverId} | {transaction.TransactionType} | {transaction.TransactionAmount} | {transaction.TransactionDate}");
            }
           await MainMethod.Logout();
        }

    }
}